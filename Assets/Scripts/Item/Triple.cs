using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : Projectile
{
    const int MAX_COUNT = 2;
    static int count = MAX_COUNT;
    float secondsBetweenShot = 0.5f;

    protected override void Start()
    {
        damage *= 0.5f;

        gamePhase = FindObjectOfType<GamePhase>();
        playerThatShootThis = gamePhase.playerThatIsInTurn;

        IgnorePlayerCollision();
        SetInitialVelocity();

        if (count == MAX_COUNT)
        {
            gamePhase.WaitProjectileToBeLanded();
        }

        if (count > 0)
        {
            StartCoroutine(ShootOnceMore());
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<Health>().ModifyHealth(-damage);
            player.GetComponent<Health>().Hit();
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        if (count <= 0)
        {
            count = MAX_COUNT;
            gamePhase.GoToNextTurn();
        }
    }

    IEnumerator ShootOnceMore()
    {
        yield return new WaitForSeconds(secondsBetweenShot);
        Transform cannonThatShootThis = playerThatShootThis.GetComponent<Cannon>().cannon;
        Instantiate(gameObject, cannonThatShootThis.position, cannonThatShootThis.rotation);
        count--;
    }
}
