﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] KeyCode moveLeftKey;
    [SerializeField] KeyCode moveRightKey;
    public float speed = 10f;
    [SerializeField] float maxGasoline = 100f;
    [SerializeField] float currentGasoline;
    public float gasolineConsumptionRates = 3f;
    [SerializeField] Image gasolineBarImg;

    public bool isMyTurn;
    public bool isDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        currentGasoline = maxGasoline;
    }

    // Update is called once per frame
    void Update()
    {
        gasolineBarImg.fillAmount = currentGasoline / maxGasoline;
        if (isMyTurn && !isDisabled)
        {
            float deltaX;
            if (Input.GetKey(moveLeftKey) && currentGasoline > 0)
            {
                deltaX = -1 * speed * Time.deltaTime;
            }
            else if (Input.GetKey(moveRightKey) && currentGasoline > 0)
            {
                deltaX = speed * Time.deltaTime;
            }
            else
            {
                deltaX = 0f;
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