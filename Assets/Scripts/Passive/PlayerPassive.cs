using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassive : MonoBehaviour
{
    public GameObject passivePrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject passive = Instantiate(passivePrefab, transform.position, Quaternion.identity);
        passive.transform.parent = transform;
    }
}
