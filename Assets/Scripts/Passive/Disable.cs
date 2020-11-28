using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;
    GameObject enemy;
    bool isDisabling = false;
    GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (isDisabling && enemy.GetComponent<Move>().isMyTurn)
        {
            enemy.GetComponent<Inventory>().isDisabled = true;
        }
        else if (enemy.GetComponent<Inventory>().isDisabled && !enemy.GetComponent<Move>().isMyTurn)
        {
            enemy.GetComponent<Inventory>().isDisabled = false;
            isDisabling = false;
            Destroy(effect);
        }

        try
        {
            if (enemy.GetComponent<Health>().IsHit() && !isDisabling)
            {
                effect = Instantiate(effectPrefab, enemy.transform.position, effectPrefab.transform.rotation);
                effect.transform.parent = enemy.transform;
                isDisabling = true;
            }
        }
        catch (MissingReferenceException ignored)
        {

        }
    }
}
