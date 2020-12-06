using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRider : MonoBehaviour
{
    GameObject self;
    float bonusSpeed = 0.3f;
    float minusGas = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        self = transform.parent.gameObject;
        self.GetComponent<Move>().speed *= (1 + bonusSpeed);
        self.GetComponent<Move>().gasolineConsumptionRates *= (1 - minusGas);
    }
}
