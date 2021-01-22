using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected GameObject deathEffect;
    public float maxHP = 100f;
    public float currentHP;
    public Image healthBarImg;

    bool isHit = false;

    [SerializeField] AudioClip deathSound;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        healthBarImg.fillAmount = currentHP / maxHP;

        if (currentHP <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            FindObjectOfType<GamePhase>().EndGame(gameObject);
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    public virtual void ModifyHealth(float deltaHP)
    {
        currentHP += deltaHP;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void Hit()
    {
        isHit = true;
    }

    public bool IsHit()
    {
        if (isHit == true)
        {
            isHit = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
