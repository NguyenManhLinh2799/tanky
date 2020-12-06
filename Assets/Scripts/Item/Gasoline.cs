using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasoline : SelfUse
{
    float gasolineRegenAmount = 30f;

    protected override void Start()
    {
        base.Start();
        Instantiate(effectPrefab, transform.position, effectPrefab.transform.rotation);
        playerThatUseThis.GetComponent<Move>().ModifyGasoline(gasolineRegenAmount);
        Destroy(gameObject, 1f);
    }
}
