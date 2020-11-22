using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : Gun
{
    private void Start()
    {
        nextRotationZ = 45f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.W))
        {
            nextRotationZ = Mathf.Clamp(transform.localEulerAngles.z + deltaZ, minAngle, maxAngle);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            nextRotationZ = Mathf.Clamp(transform.localEulerAngles.z - deltaZ, minAngle, maxAngle);
        }
    }
}
