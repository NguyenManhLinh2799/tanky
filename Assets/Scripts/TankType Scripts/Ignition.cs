using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignition : MonoBehaviour
{
    Player enemy;
    float damagePerSecond = 1f;
    int duration = 5;
    GameObject effectPrefab;

    float enemyHP;
    bool isIgniting = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player 1")
        {
            enemy = FindObjectOfType<Player2>();
        }
        else
        {
            enemy = FindObjectOfType<Player1>();
        }
        enemyHP = enemy.GetCurrentHP();
        effectPrefab = Resources.Load("Fire") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isHit && isIgniting == false) // If enemy is hit and not ignited
        {
            isIgniting = true;
            enemyHP = enemy.GetCurrentHP() - damagePerSecond * duration;
            PlayEffect();
            StartCoroutine(IgniteLoop());
        }
    }

    private void PlayEffect()
    {
        var effect = Instantiate(effectPrefab, enemy.transform.position, Quaternion.identity);
        effect.transform.parent = enemy.transform; // In case enemy die before the effect ends
        Destroy(effect, duration);
    }

    IEnumerator IgniteLoop()
    {
        for (int i = 0; i < duration; i++)
        {
            yield return StartCoroutine(Ignite());
        }
        isIgniting = false; // Finish igniting
        enemy.isHit = false;
    }

    IEnumerator Ignite()
    {
        yield return new WaitForSeconds(1);
        enemy.SetCurrentHP(enemy.GetCurrentHP() - damagePerSecond);
    }
}
