using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : SelfUse
{
    GameObject enemy;
    float distanceFromPlayer = 2f;
    float xOffset;
    float yOffset = 0.5f;
    int hitCount = 3;

    protected override void Start()
    {
        base.Start();

        // Replace the old shield if exists
        Shield[] shields = FindObjectsOfType<Shield>();
        foreach (Shield shield in shields)
        {
            if (shield.playerThatUseThis == playerThatUseThis && shield != this)
            {
                Destroy(shield.gameObject);
            }
        }

        // Detect enemy
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player != playerThatUseThis)
            {
                enemy = player;
            }
        }

        // Place the shield towards enemy
        if (enemy.transform.position.x > playerThatUseThis.transform.position.x)
        {
            xOffset = distanceFromPlayer;
        }
        else
        {
            xOffset = -distanceFromPlayer;
        }
    }

    private void Update()
    {
        try
        {
            // Follow player
            transform.position = new Vector3(playerThatUseThis.transform.position.x + xOffset,
                playerThatUseThis.transform.position.y + yOffset);

            // If player is in turn, disable collider
            if (playerThatUseThis.GetComponent<Move>().isMyTurn && !enemy.GetComponent<Move>().isMyTurn)
            {
                GetComponent<Collider2D>().enabled = false;
            }
            else if (!playerThatUseThis.GetComponent<Move>().isMyTurn && enemy.GetComponent<Move>().isMyTurn)
            {
                GetComponent<Collider2D>().enabled = true;
            }
        }
        catch (MissingReferenceException ignored)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            hitCount--;
        }

        if (hitCount <= 0)
        {
            Instantiate(effectPrefab, transform.position, effectPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}
