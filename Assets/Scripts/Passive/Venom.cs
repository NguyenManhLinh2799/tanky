using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venom : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;
    GameObject enemy;
    int duration = 5;
    float damagePerSecond = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Detect enemy
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            if (player != transform.parent.gameObject)
            {
                enemy = player;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (enemy.GetComponent<Health>().IsHit())
            {
                GameObject effect = Instantiate(effectPrefab, enemy.transform.position, effectPrefab.transform.rotation);
                effect.transform.parent = enemy.transform;
                StartCoroutine(Poisoning());
            }
        }
        catch (MissingReferenceException ignored)
        {

        }
    }

    IEnumerator Poisoning()
    {
        for (int i = 0; i < duration; i++)
        {
            yield return Poison();
        }
    }

    IEnumerator Poison()
    {
        yield return new WaitForSeconds(1);
        try
        {
            enemy.GetComponent<Health>().ModifyHealth(-damagePerSecond);
        }
        catch (MissingReferenceException ignored)
        {

        }
    }
}
