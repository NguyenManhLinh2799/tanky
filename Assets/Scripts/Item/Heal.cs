using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : SelfUse
{
    float healAmount = 20f;

    protected override void Start()
    {
        base.Start();
        Instantiate(effectPrefab, transform.position, effectPrefab.transform.rotation);
        playerThatUseThis.GetComponent<Health>().ModifyHealth(healAmount);
        Destroy(gameObject, 1f);
    }
}
