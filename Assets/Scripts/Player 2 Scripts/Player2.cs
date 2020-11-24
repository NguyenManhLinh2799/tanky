using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : Player
{
    protected override void Start()
    {
        base.Start();

        healthBarImg = GameObject.FindGameObjectWithTag("Health Bar 2").GetComponent<Image>();
        gasolineBarImg = GameObject.FindGameObjectWithTag("Gasoline Bar 2").GetComponent<Image>();

        shootKey = KeyCode.KeypadEnter;
        moveLeftKey = KeyCode.LeftArrow;
        moveRightKey = KeyCode.RightArrow;

        activateItem1 = KeyCode.Keypad1;
        activateItem2 = KeyCode.Keypad2;
        activateItem3 = KeyCode.Keypad3;

        if (gameSelection.player2Type == GameSelection.TankType.Ignition)
        {
            gameObject.AddComponent<Ignition>();
        }
    }

    public override bool IsMyTurn()
    {
        return gamePhase.IsPlayer2Turn();
    }
}
