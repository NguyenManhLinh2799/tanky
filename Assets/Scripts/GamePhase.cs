using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhase : MonoBehaviour
{
    // Config params
    [SerializeField] float secondsBeforeNextTurn = 2f;

    // Cache references
    CameraController cameraController;

    // State variables
    public bool isPlayer1Turn = true;
    bool isBulletLanded = true;
    public int acivatedIndex = -1;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    public int GetActivatedIndex()
    {
        return acivatedIndex;
    }

    public void ActivateItem(int index)
    {
        acivatedIndex = index;
    }

    public void SwitchToPlayer1Turn()
    {
        isPlayer1Turn = true;
    }

    public void SwitchToPlayer2Turn()
    {
        isPlayer1Turn = false;
    }

    public void StartLaunchingPhase()
    {
        isBulletLanded = false;
        cameraController.FollowBullet();
    }

    public void EndLaunchingPhase()
    {
        StartCoroutine(WaitBeforeNextTurn());
    }

    public bool IsPlayer1Turn()
    {
        return isPlayer1Turn && isBulletLanded;
    }

    public bool IsPlayer2Turn()
    {
        return !isPlayer1Turn && isBulletLanded;
    }

    IEnumerator WaitBeforeNextTurn()
    {
        yield return new WaitForSeconds(secondsBeforeNextTurn);
        if (isPlayer1Turn)
        {
            SwitchToPlayer2Turn();
            cameraController.FollowPlayer2();
        }
        else
        {
            SwitchToPlayer1Turn();
            cameraController.FollowPlayer1();
        }
        isBulletLanded = true;
    }
}
