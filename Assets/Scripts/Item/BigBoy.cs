using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoy : Projectile
{
    float scaleTimes = 2f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        transform.localScale = new Vector2(transform.localScale.x * scaleTimes, transform.localScale.y * scaleTimes);
        damage *= scaleTimes;
    }
}
