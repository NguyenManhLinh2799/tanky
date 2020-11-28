using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GamePhase gamePhase;
    GameObject gameObjectToBeFollowed;

    private void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
        FollowPlayer1();
    }

    private void Update()
    {
        if (gameObjectToBeFollowed != null)
        {
            transform.position = new Vector3(gameObjectToBeFollowed.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    public void FollowPlayer1()
    {
        gameObjectToBeFollowed = gamePhase.player1;
    }

    public void FollowPlayer2()
    {
        gameObjectToBeFollowed = gamePhase.player2;
    }

    public void FollowProjectile()
    {
        gameObjectToBeFollowed = GameObject.FindGameObjectWithTag("Projectile");
    }
}
