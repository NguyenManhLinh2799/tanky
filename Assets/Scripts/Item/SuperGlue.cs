﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGlue : Projectile
{
    GameObject enemy;
    GameObject gluedEffect;
    bool isAffecting = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        gamePhase.GoToNextTurn();

        if (collision.gameObject.tag == "Player")
        {
            enemy = collision.gameObject;

            gluedEffect = Instantiate(effectPrefab, enemy.transform.position, effectPrefab.transform.rotation);
            gluedEffect.transform.parent = enemy.transform;

            enemy.GetComponent<Health>().ModifyHealth(-damage);
            enemy.GetComponent<Health>().Hit();

            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<Collider2D>());
            gameObject.tag = "Untagged";

            isAffecting = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        try
        {
            if (enemy.GetComponent<Move>().isMyTurn && isAffecting)
            {
                enemy.GetComponent<Move>().isDisabled = true;
                enemy.GetComponent<Cannon>().isDisabled = true;
            }
            else if (!enemy.GetComponent<Move>().isMyTurn && enemy.GetComponent<Move>().isDisabled && enemy.GetComponent<Cannon>().isDisabled)
            {
                isAffecting = false;
                enemy.GetComponent<Move>().isDisabled = false;
                enemy.GetComponent<Cannon>().isDisabled = false;
                Destroy(gluedEffect);
                Destroy(gameObject);
            }
        }
        catch (NullReferenceException ignored)
        {

        }
        catch (MissingReferenceException ignored)
        {

        }
    }
}
