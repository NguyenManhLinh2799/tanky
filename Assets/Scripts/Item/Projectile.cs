using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float damage = 15f;
    [SerializeField] protected GameObject explosionEffect;
    protected GamePhase gamePhase;
    protected static GameObject playerThatShootThis;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
        gamePhase.WaitProjectileToBeLanded();

        playerThatShootThis = gamePhase.playerThatIsInTurn;

        IgnorePlayerCollision();
        SetInitialVelocity();
    }

    protected void SetInitialVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = playerThatShootThis.GetComponent<Cannon>().GetInitialVelocity();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<Health>().ModifyHealth(-damage);
            player.GetComponent<Health>().Hit();
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        gamePhase.GoToNextTurn();
        Destroy(gameObject);
    }

    protected void IgnorePlayerCollision()
    {
        Collider2D playerCollider = playerThatShootThis.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);
    }
}
