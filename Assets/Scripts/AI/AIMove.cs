using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : Move
{
    AIInventory inventoryComponent;
    float moveTime = 0.75f;
    float timer = 0f;
    public int randomDirection = 1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        inventoryComponent = GetComponent<AIInventory>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        gasolineBarImg.fillAmount = currentGasoline / maxGasoline;

        if (timer > 0 && isMyTurn)
        {
            if (!moveSound.isPlaying)
            {
                moveSound.Play();
            }

            timer -= Time.deltaTime;
            float deltaX = randomDirection * speed * Time.deltaTime;

            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);

            currentGasoline -= gasolineConsumptionRates * Mathf.Abs(deltaX);

            if (timer <= 0 || currentGasoline <= 0)
            {
                moveSound.Stop();
                inventoryComponent.isDelayed = false;
            }
        }
    }

    public void MoveTank()
    {
        if (!isDisabled && currentGasoline > 0 && timer <= 0)
        {
            timer = moveTime;
            inventoryComponent.isDelayed = true;

            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                randomDirection = -1;
            }
            else
            {
                randomDirection = 1;
            }
        }
    }
}
