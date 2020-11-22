using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Slider>().value += 0.1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Slider>().value -= 0.1f;
        }
    }
}
