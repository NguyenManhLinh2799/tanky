using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    // Config params
    float rotationSpeed = 15f;
    float maxAngle = 75f;
    float minAngle = 0f;
    float powerAdjustSpeed = 10f;
    
    [SerializeField] KeyCode increaseAngleKey;
    [SerializeField] KeyCode decreaseAngleKey;
    [SerializeField] KeyCode increasePowerKey;
    [SerializeField] KeyCode decreasePowerKey;

    // References
    [SerializeField] GameObject shootVFX;
    public Transform cannonTransform;
    public Transform barrelTransform;
    public Slider powerSlider;
    AudioSource rotateSound;

    public bool isDisabled = false;
    public bool isLeftDirection;

    protected SpriteRenderer spriteRenderer;

    private void Start()
    {
        rotateSound = cannonTransform.GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isDisabled)
        {
            AdjustAngle();
        }
        AdjustPower();
    }

    public void PlayShootEffect()
    {
        Instantiate(shootVFX, barrelTransform.position, Quaternion.identity);
    }

    private void AdjustPower()
    {
        if (Input.GetKey(increasePowerKey))
        {
            if (!rotateSound.isPlaying)
            {
                rotateSound.Play();
            }
            powerSlider.value += powerAdjustSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(decreasePowerKey))
        {
            if (!rotateSound.isPlaying)
            {
                rotateSound.Play();
            }
            powerSlider.value -= powerAdjustSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyUp(increasePowerKey) || Input.GetKeyUp(decreasePowerKey))
        {
            rotateSound.Stop();
        }
    }

    private void AdjustAngle()
    {
        float nextAngle = cannonTransform.localEulerAngles.z;
        if (Input.GetKey(increaseAngleKey))
        {
            if (!rotateSound.isPlaying)
            {
                rotateSound.Play();
            }
            nextAngle = Mathf.Clamp(cannonTransform.localEulerAngles.z + rotationSpeed * Time.deltaTime, minAngle, maxAngle);
        }
        else if (Input.GetKey(decreaseAngleKey))
        {
            if (!rotateSound.isPlaying)
            {
                rotateSound.Play();
            }
            nextAngle = Mathf.Clamp(cannonTransform.localEulerAngles.z - rotationSpeed * Time.deltaTime, minAngle, maxAngle);
        }
        else if (Input.GetKeyUp(increaseAngleKey) || Input.GetKeyUp(decreaseAngleKey))
        {
            rotateSound.Stop();
        }

        if (nextAngle > maxAngle - 1)
        {
            nextAngle -= 5;
            isLeftDirection = !isLeftDirection;

            spriteRenderer.flipX = !spriteRenderer.flipX;
            cannonTransform.localPosition = new Vector3(
                -cannonTransform.localPosition.x,
                cannonTransform.localPosition.y,
                cannonTransform.localPosition.z);
            cannonTransform.Rotate(0f, 180f, 0f);
        }

        cannonTransform.localEulerAngles = new Vector3(0f, cannonTransform.localEulerAngles.y, nextAngle);
    }

    public virtual Vector2 GetInitialVelocity()
    {
        float power = powerSlider.value;
        float angleDegree = cannonTransform.eulerAngles.z;
        if (isLeftDirection)
        {
            angleDegree = 180 - angleDegree;
        }
        float angleRadian = angleDegree * Mathf.Deg2Rad;
        return new Vector2(power * Mathf.Cos(angleRadian), power * Mathf.Sin(angleRadian));
    }
}
