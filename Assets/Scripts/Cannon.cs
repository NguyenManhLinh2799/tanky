using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    // Config params
    float rotationSpeed = 100f;
    float maxAngle = 180f;
    float minAngle = 0f;
    float powerAdjustSpeed = 10f;
    public Transform cannonTransform;
    [SerializeField] KeyCode rotateClockwiseKey;
    [SerializeField] KeyCode rotateCounterclockwiseKey;
    [SerializeField] KeyCode increasePowerKey;
    [SerializeField] KeyCode decreasePowerKey;

    // References
    [SerializeField] GameObject powerSlider;

    public bool isDisabled = false;

    void Update()
    {
        if (!isDisabled)
        {
            Rotate();
        }
        AdjustPower();
    }

    private void AdjustPower()
    {
        if (Input.GetKey(increasePowerKey))
        {
            powerSlider.GetComponent<Slider>().value += powerAdjustSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(decreasePowerKey))
        {
            powerSlider.GetComponent<Slider>().value -= powerAdjustSpeed * Time.deltaTime;
        }
    }

    private void Rotate()
    {
        float nextRotationZ = cannonTransform.localEulerAngles.z;
        if (Input.GetKey(rotateCounterclockwiseKey))
        {
            nextRotationZ = Mathf.Clamp(cannonTransform.localEulerAngles.z + rotationSpeed * Time.deltaTime, minAngle, maxAngle);
        }
        else if (Input.GetKey(rotateClockwiseKey))
        {
            nextRotationZ = Mathf.Clamp(cannonTransform.localEulerAngles.z - rotationSpeed * Time.deltaTime, minAngle, maxAngle);
        }
        cannonTransform.localEulerAngles = new Vector3(0f, 0f, nextRotationZ);
    }

    public Vector2 GetInitialVelocity()
    {
        float power = powerSlider.GetComponent<Slider>().value;
        float angleRadian = cannonTransform.localEulerAngles.z * Mathf.Deg2Rad;
        return new Vector2(power * Mathf.Cos(angleRadian), power * Mathf.Sin(angleRadian));
    }
}
