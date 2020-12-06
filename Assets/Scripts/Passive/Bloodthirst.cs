using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodthirst : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;
    GameObject self;
    GameObject enemy;
    float damage;
    float lifeStealPercentage = 0.3f;

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
        GameObject projectile = GameObject.FindGameObjectWithTag("Projectile");
        if (projectile != null)
        {
            damage = projectile.GetComponent<Projectile>().damage;
        }

        try
        {
            if (enemy.GetComponent<Health>().IsHit())
            {
                self.GetComponent<Health>().ModifyHealth(damage * lifeStealPercentage);
                Instantiate(effectPrefab, transform.position, effectPrefab.transform.rotation);
            }
        }
        catch (MissingReferenceException ignored)
        {

        }
    }
}
