using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile
{
    float secondsBeforeBlowing = 2f;
    bool isBlown = false;
    float shockwaveRadius = 2f;
    float dmgScale = 2f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBlown)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Health>().ModifyHealth(-damage * dmgScale);                
            }
            Destroy(gameObject);
        }
        else
        {
            isLanded = true;
            StartCoroutine(WaitThenBlow());
        }
    }

    IEnumerator WaitThenBlow()
    {
        yield return new WaitForSeconds(secondsBeforeBlowing);

        if (impactSound != null)
        {
            AudioSource.PlayClipAtPoint(impactSound, transform.position);
        }

        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(4f, 4f, 0f);

        isBlown = true;
        Destroy(GetComponent<Collider2D>());
        CircleCollider2D shockwave = gameObject.AddComponent<CircleCollider2D>();
        shockwave.radius = shockwaveRadius;

        gamePhase.GoToNextTurn();
    }
}
