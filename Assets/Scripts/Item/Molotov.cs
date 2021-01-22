using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : Projectile
{
    float delayedSeconds = 1f;
    float scaleDamage = 0.25f;

    [SerializeField] GameObject fireChildEffect;

    public GameObject fireEffect;

    protected override void Start()
    {
        base.Start();

        damage *= scaleDamage;
        StartCoroutine(RepeatIgnition());
    }

    IEnumerator RepeatIgnition()
    {
        while (true)
        {
            yield return Ignite();
        }
    }

    IEnumerator Ignite()
    {
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(delayedSeconds);
        GetComponent<Collider2D>().enabled = false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isLanded = true;
            fireChildEffect.SetActive(false);

            fireEffect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            fireEffect.transform.localScale = new Vector3(2f, 2f, 0f);

            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<SpriteRenderer>());

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            BoxCollider2D fire = gameObject.AddComponent<BoxCollider2D>();
            fire.size = new Vector2(2f, 2f);
            fire.isTrigger = true;

            gameObject.tag = "Untagged";

            gamePhase.GoToNextTurn();
        }
    }

    protected override void IgnorePlayerCollision()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().ModifyHealth(-damage);
        }
    }
}
