using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    // Config params
    [SerializeField] GameObject VFX;
    [SerializeField] float damage = 15f;

    // Cached references
    GameSelection gameSelection;
    GamePhase gamePhase;
    Slider powerSlider;
    Cannon cannon;
    Player playerThatShootThis;

    // State variables
    Vector2 startPosition;
    float initialVelocityX = 10f;
    float initialVelocityY = 10f;
    float power = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Find references
        gameSelection = FindObjectOfType<GameSelection>();
        gamePhase = FindObjectOfType<GamePhase>();
        
        if (gamePhase.IsPlayer1Turn())
        {
            playerThatShootThis = FindObjectOfType<Player1>();
            powerSlider = FindObjectOfType<PowerController1>().GetComponent<Slider>();
            cannon = FindObjectOfType<Cannon1>();
        }
        else if (gamePhase.IsPlayer2Turn())
        {
            playerThatShootThis = FindObjectOfType<Player2>();
            powerSlider = FindObjectOfType<PowerController2>().GetComponent<Slider>();
            cannon = FindObjectOfType<Cannon2>();
        }

        // Set start position
        SetStartPosition();

        // Ignore collision of whoever shoot this
        IgnorePlayerCollision();

        // Set velocity
        SetPower();
        CalculateInitialVelocity();
        GetComponent<Rigidbody2D>().velocity = new Vector2(initialVelocityX, initialVelocityY);

        // Activate item
        ActivateItem();

        gamePhase.StartLaunchingPhase(); // Prevent from shooting multiple times
    }

    public Player GetPlayerThatShootThis()
    {
        return playerThatShootThis;
    }

    private void SetStartPosition()
    {
        startPosition = playerThatShootThis.transform.position;
    }

    public Vector2 GetStartPosition()
    {
        return startPosition;
    }

    private void IgnorePlayerCollision()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerThatShootThis.GetComponent<Collider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(VFX, transform.position, transform.rotation);
        explosion.transform.localScale = new Vector3(
            explosion.transform.localScale.x * transform.localScale.x,
            explosion.transform.localScale.y * transform.localScale.y,
            0f);
        gameObject.SetActive(false);
        Destroy(gameObject);
        
        gamePhase.EndLaunchingPhase();
    }

    private void CalculateInitialVelocity()
    {
        float angleRad = 0f;
        angleRad = cannon.GetAngleRadian();
        initialVelocityX = power * Mathf.Cos(angleRad);
        initialVelocityY = power * Mathf.Sin(angleRad);
    }

    public Vector2 GetInitialVelocity()
    {
        return new Vector2(initialVelocityX, initialVelocityY);
    }

    public void SetPower()
    {
        power = powerSlider.value;
    }

    public float GetPower()
    {
        return power;
    }

    public void ActivateItem()
    {
        if (gamePhase.GetActivatedIndex() == -1) return; // No item is activated

        GameSelection.Item item;
        if (gamePhase.IsPlayer1Turn())
        {
            item = gameSelection.player1Items[gamePhase.GetActivatedIndex()];
        }
        else
        {
            item = gameSelection.player2Items[gamePhase.GetActivatedIndex()];
        }

        // Check which item is activated
        if (item == GameSelection.Item.Triple)
        {
            gameObject.AddComponent<Triple>();
        }
        gamePhase.ActivateItem(-1);
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
