using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject gameObjectToBeFollowed;

    private void Update()
    {
        if (gameObjectToBeFollowed != null)
        {
            transform.position = new Vector3(gameObjectToBeFollowed.transform.position.x, gameObjectToBeFollowed.transform.position.y, transform.position.z);
        }
    }

    public void Follow(GameObject gameObject)
    {
        gameObjectToBeFollowed = gameObject;
    }

    public void FollowProjectile()
    {
        gameObjectToBeFollowed = GameObject.FindGameObjectWithTag("Projectile");
    }
}
