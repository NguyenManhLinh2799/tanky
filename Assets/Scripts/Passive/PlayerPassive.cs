using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassive : MonoBehaviour
{
    public GameObject passivePrefab;

    public float R;
    public float G;
    public float B;
    [SerializeField] SpriteRenderer tankCannon;

    // Start is called before the first frame update
    void Start()
    {
        GameObject passive = Instantiate(passivePrefab, transform.position, Quaternion.identity);
        passive.transform.parent = transform;

        GetComponent<SpriteRenderer>().color = tankCannon.color = new Color(R, G, B);
    }
}
