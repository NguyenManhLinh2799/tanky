using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensity : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;
    GameObject self;
    GameObject enemy;
    float lostHpPercentage = 0.05f; // Deal bonus damage by lost HP percentage

    void Start()
    {
        self = transform.parent.gameObject;
        // Detect enemy
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player != transform.parent.gameObject)
            {
                enemy = player;
            }
        }
    }

    void Update()
    {
        try
        {
            if (enemy.GetComponent<Health>().IsHit())
            {
                float selfLostHP = self.GetComponent<Health>().maxHP - self.GetComponent<Health>().currentHP;
                float enemyLostHP = enemy.GetComponent<Health>().maxHP - enemy.GetComponent<Health>().currentHP;
                enemy.GetComponent<Health>().ModifyHealth(-(selfLostHP + enemyLostHP) * lostHpPercentage);
            }
        }
        catch (MissingReferenceException ignored)
        {

        }
    }
}
