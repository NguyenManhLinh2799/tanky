using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    // Config params
    [SerializeField] GameObject VFX;

    // Cached references
    GamePhase gamePhase;
    Slider powerSlider1;
    Slider powerSlider2;
    Gun1 gun1;
    Gun2 gun2;
    Player1 player1;
    Player2 player2;

    // State variables
    bool isLanded = false;
    float initialVelocityX = 10f;
    float initialVelocityY = 10f;
    float power = 10f;
    float damage = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        // Find references
        gamePhase = FindObjectOfType<GamePhase>();
        powerSlider1 = FindObjectOfType<PowerController1>().GetComponent<Slider>();
        powerSlider2 = FindObjectOfType<PowerController2>().GetComponent<Slider>();
        gun1 = FindObjectOfType<Gun1>();
        gun2 = FindObjectOfType<Gun2>();
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();

        // Ignore collision of whatever shoot this
        if (gamePhase.IsPlayer1Turn())
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player1.GetComponent<Collider2D>());
        }
        else if (gamePhase.IsPlayer2Turn())
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player2.GetComponent<Collider2D>());
        }

        // Set velocity
        SetPower();
        CalculateInitialVelocity();
        GetComponent<Rigidbody2D>().velocity = new Vector2(initialVelocityX, initialVelocityY);

        // Set item
        ActivateItem();

        gamePhase.StartLaunchingPhase(); // Prevent from shooting multiple times
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(VFX, transform.position, transform.rotation);
        gamePhase.EndLaunchingPhase();
    }

    private void CalculateInitialVelocity()
    {
        float angleRad = 0f;
        if (gamePhase.IsPlayer1Turn())
        {
            angleRad = gun1.GetAngleRadian();
        }
        else if (gamePhase.IsPlayer2Turn())
        {
            angleRad = gun2.GetAngleRadian();
        }
        initialVelocityX = power * Mathf.Cos(angleRad);
        initialVelocityY = power * Mathf.Sin(angleRad);
    }

    public void SetPower()
    {
        if (gamePhase.IsPlayer1Turn())
        {
            power = powerSlider1.value;
        }
        else if (gamePhase.IsPlayer2Turn())
        {
            power = powerSlider2.value;
        }
    }

    public void ActivateItem()
    {
        if (gamePhase.GetPlayerActivatedItem() == 1)
        {
            gameObject.AddComponent<BigBoy>();
        }
        gamePhase.SetPlayerActivatedItem(0);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
