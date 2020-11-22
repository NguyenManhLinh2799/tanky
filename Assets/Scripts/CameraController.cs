using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Cached references
    GameObject gameObjectToBeFollowed;

    private void Start()
    {
        gameObjectToBeFollowed = GameObject.FindGameObjectWithTag("Player 1");
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
        gameObjectToBeFollowed = GameObject.FindGameObjectWithTag("Player 1");
    }

    public void FollowPlayer2()
    {
        gameObjectToBeFollowed = GameObject.FindGameObjectWithTag("Player 2");
    }

    public void FollowBullet()
    {
        gameObjectToBeFollowed = GameObject.FindGameObjectWithTag("Bullet");
    }
}
