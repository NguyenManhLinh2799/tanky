using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfUse : MonoBehaviour
{
    protected GamePhase gamePhase;
    protected GameObject playerThatUseThis;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
        playerThatUseThis = gamePhase.playerThatIsInTurn;
        gamePhase.GoToNextTurn();
    }
}
