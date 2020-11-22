using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            GetComponent<Slider>().value += 0.1f;
        }
        else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            GetComponent<Slider>().value -= 0.1f;
        }
    }
}
