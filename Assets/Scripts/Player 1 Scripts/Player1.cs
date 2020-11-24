using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : Player
{
    protected override void Start()
    {
        base.Start();

        healthBarImg = GameObject.FindGameObjectWithTag("Health Bar 1").GetComponent<Image>();
        gasolineBarImg = GameObject.FindGameObjectWithTag("Gasoline Bar 1").GetComponent<Image>();

        shootKey = KeyCode.Space;
        moveLeftKey = KeyCode.A;
        moveRightKey = KeyCode.D;

        activateItem1 = KeyCode.Alpha1;
        activateItem2 = KeyCode.Alpha2;
        activateItem3 = KeyCode.Alpha3;

        if (gameSelection.player1Type == GameSelection.TankType.Ignition)
        {
            gameObject.AddComponent<Ignition>();
        }
    }

    public override bool IsMyTurn()
    {
        return gamePhase.IsPlayer1Turn();
    }
}
