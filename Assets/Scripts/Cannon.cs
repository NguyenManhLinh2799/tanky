using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    // Config params
    [SerializeField] protected float deltaZ = 1f;
    [SerializeField] protected float maxAngle = 180f;
    [SerializeField] protected float minAngle = 0f;

    // State variables
    protected float nextRotationZ;

    protected virtual void Update()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, nextRotationZ);
    }

    public float GetAngleRadian()
    {
        return transform.localEulerAngles.z * Mathf.Deg2Rad;
    }
}
