using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : MonoBehaviour
{
    Player playerThatShotThis;
    float secondsBetweenShot = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        playerThatShotThis = GetComponent<Bullet>().GetPlayerThatShootThis();

        StartCoroutine(WaitAndRepeatShooting());
    }

    IEnumerator WaitAndRepeatShooting()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return StartCoroutine(ShootAnotherOne());
        }
    }

    IEnumerator ShootAnotherOne()
    {
        yield return new WaitForSeconds(secondsBetweenShot);
        GameObject bulletClone = Resources.Load("BulletClone") as GameObject;
        Instantiate(bulletClone, playerThatShotThis.transform.position, playerThatShotThis.transform.rotation);
    }
}
