using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePhase : MonoBehaviour
{
    // Config params
    public GameObject player1;
    public GameObject player2;
    [SerializeField] float secondsBeforeNextTurn = 2f;
    [SerializeField] Message message;

    // Cache references
    CameraController cameraController;

    // State variables
    public bool isPlayer1Turn;
    public GameObject playerThatIsInTurn;
    public bool isWaiting = false;

    private void Start()
    {
        message.gameObject.SetActive(false);

        cameraController = FindObjectOfType<CameraController>();

        SwitchToPlayer1Turn();
        //SwitchToPlayer2Turn();
    }

    public void SwitchToPlayer1Turn()
    {
        try
        {
            ShowMessage("Lượt người chơi 1");

            player1.GetComponent<Move>().isMyTurn = true;
            player2.GetComponent<Move>().isMyTurn = false;
            playerThatIsInTurn = player1;
            isPlayer1Turn = true;
            cameraController.Follow(player1);
        }
        catch (MissingReferenceException)
        {

        }
    }

    public void SwitchToPlayer2Turn()
    {
        try
        {
            ShowMessage("Lượt người chơi 2");

            player2.GetComponent<Move>().isMyTurn = true;
            player1.GetComponent<Move>().isMyTurn = false;
            playerThatIsInTurn = player2;
            isPlayer1Turn = false;
            cameraController.Follow(player2);
        }
        catch (MissingReferenceException)
        {

        }
    }

    public void WaitProjectileToBeLanded()
    {
        try
        {
            player1.GetComponent<Move>().isMyTurn = false;
            player2.GetComponent<Move>().isMyTurn = false;
            cameraController.FollowProjectile();
        }
        catch (MissingReferenceException)
        {

        }
    }

    public void GoToNextTurn()
    {
        isWaiting = true;
        StartCoroutine(WaitBeforeNextTurn());
    }

    IEnumerator WaitBeforeNextTurn()
    {
        try
        {
            player1.GetComponent<Move>().isMyTurn = false;
            player2.GetComponent<Move>().isMyTurn = false;
        }
        catch (MissingReferenceException)
        {

        }

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

    void ShowMessage(string msg)
    {
        message.gameObject.SetActive(true);
        message.Show(msg);
    }

    public void EndGame(GameObject playerLost)
    {
        var playerWon = GameObject.FindGameObjectWithTag("Player");
        playerWon.GetComponent<Move>().isDisabled = true;
        playerWon.GetComponent<Inventory>().isDisabled = true;
        StartCoroutine(WaitThenShowMessage(playerLost));
    }

    IEnumerator WaitThenShowMessage(GameObject playerLost)
    {
        yield return new WaitForSeconds(secondsBeforeNextTurn);
        if (playerLost == player1)
        {
            cameraController.Follow(player2);
        }
        else
        {
            cameraController.Follow(player1);
        }

        message.gameObject.SetActive(true);
        message.Show("Kết thúc");
    }
}
