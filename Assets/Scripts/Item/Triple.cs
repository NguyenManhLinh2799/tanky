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
        damage *= 0.6f;

        gamePhase = FindObjectOfType<GamePhase>();
        playerThatShootThis = gamePhase.playerThatIsInTurn;

        audioSource = GetComponent<AudioSource>();

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

        PlayShootEffect();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (impactSound != null)
        {
            AudioSource.PlayClipAtPoint(impactSound, transform.position);
        }

        if (!isLanded)
        {
            isLanded = true;
            if (collision.gameObject.tag == "Player")
            {
                GameObject player = collision.gameObject;
                player.GetComponent<Health>().ModifyHealth(-damage);
                player.GetComponent<Health>().Hit();
            }
            if (count <= 0)
            {
                count = MAX_COUNT;
                gamePhase.GoToNextTurn();
            }
            Instantiate(effectPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    IEnumerator ShootOnceMore()
    {
        yield return new WaitForSeconds(secondsBetweenShot);
        Transform cannonThatShootThis = playerThatShootThis.GetComponent<Cannon>().cannonTransform;
        Instantiate(gameObject, cannonThatShootThis.position, cannonThatShootThis.rotation);
        count--;
    }
}
