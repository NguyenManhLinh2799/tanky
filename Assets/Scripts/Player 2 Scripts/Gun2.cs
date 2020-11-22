using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : Gun
{
    private void Start()
    {
        nextRotationZ = 135f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.DownArrow))
        {
            nextRotationZ = Mathf.Clamp(transform.localEulerAngles.z + deltaZ, minAngle, maxAngle);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            nextRotationZ = Mathf.Clamp(transform.localEulerAngles.z - deltaZ, minAngle, maxAngle);
        }
    }
}
