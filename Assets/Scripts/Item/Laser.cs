using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    float duration = 2f;
    float secondsBeforeSelfDestruct;

    protected override void Start()
    {
        base.Start();

        GetComponent<Collider2D>().isTrigger = true;

        secondsBeforeSelfDestruct = duration;

        damage *= 4;
    }

    protected override void Update()
    {
        base.Update();

        secondsBeforeSelfDestruct -= Time.deltaTime;
        if (secondsBeforeSelfDestruct <= 0)
        {
            DestroyLaser();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (impactSound != null)
            {
                AudioSource.PlayClipAtPoint(impactSound, transform.position);
            }
            GameObject player = collider.gameObject;
            damage *= secondsBeforeSelfDestruct / duration;
            player.GetComponent<Health>().ModifyHealth(-damage);
            player.GetComponent<Health>().Hit();
            DestroyLaser();
        }
    }

    private void DestroyLaser()
    {
        Destroy(gameObject);
        Instantiate(effectPrefab, transform.position, transform.rotation);
        gamePhase.GoToNextTurn();
    }
}
