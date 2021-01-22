using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    AIMove aiMoveComponent;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        aiMoveComponent = GetComponent<AIMove>();
    }

    public override void ModifyHealth(float deltaHP)
    {
        base.ModifyHealth(deltaHP);
        if (deltaHP < 0)
        {
            aiMoveComponent.MoveTank();
        }
    }
}
