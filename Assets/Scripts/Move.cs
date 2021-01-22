using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] KeyCode moveLeftKey;
    [SerializeField] KeyCode moveRightKey;
    public float speed = 10f;
    [SerializeField] protected float maxGasoline = 100f;
    [SerializeField] protected float currentGasoline;
    public float gasolineConsumptionRates = 3f;
    public Image gasolineBarImg;

    public bool isMyTurn;
    public bool isDisabled = false;

    protected AudioSource moveSound;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentGasoline = maxGasoline;
        moveSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        gasolineBarImg.fillAmount = currentGasoline / maxGasoline;
        if (isMyTurn && !isDisabled)
        {
            float deltaX = 0f;
            if (Input.GetKey(moveLeftKey) && currentGasoline > 0)
            {
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }
                
                deltaX = -1 * speed * Time.deltaTime;
            }
            else if (Input.GetKey(moveRightKey) && currentGasoline > 0)
            {
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }

                deltaX = speed * Time.deltaTime;
            }
            else if (Input.GetKeyUp(moveLeftKey) || Input.GetKeyUp(moveRightKey))
            {
                moveSound.Stop();
            }

            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);

            currentGasoline -= gasolineConsumptionRates * Mathf.Abs(deltaX);
        }
    }

    public void ModifyGasoline(float deltaGasoline)
    {
        currentGasoline += deltaGasoline;
        currentGasoline = Mathf.Clamp(currentGasoline, 0f, maxGasoline);
    }
}
