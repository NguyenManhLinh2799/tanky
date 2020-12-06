using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhase : MonoBehaviour
{
    // Config params
    public GameObject player1;
    public GameObject player2;
    [SerializeField] float secondsBeforeNextTurn = 2f;

    // Cache references
    CameraController cameraController;

    // State variables
    public bool isPlayer1Turn;
    public GameObject playerThatIsInTurn;
    public bool isWaiting = false;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();

        SwitchToPlayer1Turn();
    }

    public void SwitchToPlayer1Turn()
    {
        try
        {
            player1.GetComponent<Move>().isMyTurn = true;
            player2.GetComponent<Move>().isMyTurn = false;
            playerThatIsInTurn = player1;
            isPlayer1Turn = true;
            cameraController.Follow(player1);
        }
        catch (MissingReferenceException ignored)
        {

        }
    }

    public void SwitchToPlayer2Turn()
    {
        try
        {
            player2.GetComponent<Move>().isMyTurn = true;
            player1.GetComponent<Move>().isMyTurn = false;
            playerThatIsInTurn = player2;
            isPlayer1Turn = false;
            cameraController.Follow(player2);
        }
        catch (MissingReferenceException ignored)
        {

        }
    }

    public void WaitProjectileToBeLanded()
    {
        player1.GetComponent<Move>().isMyTurn = false;
        player2.GetComponent<Move>().isMyTurn = false;
        cameraController.FollowProjectile();
    }

    public void GoToNextTurn()
    {
        isWaiting = true;
        StartCoroutine(WaitBeforeNextTurn());
    }

    IEnumerator WaitBeforeNextTurn()
    {
        player1.GetComponent<Move>().isMyTurn = false;
        player2.GetComponent<Move>().isMyTurn = false;

        yield return new WaitForSeconds(secondsBeforeNextTurn);

        if (isPlayer1Turn)
        {
            SwitchToPlayer2Turn();
        }
        else
        {
            SwitchToPlayer1Turn();
        }
        isWaiting = false;
    }
}
