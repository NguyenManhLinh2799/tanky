using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected GameObject deathEffect;
    public float maxHP = 100f;
    public float currentHP;
    [SerializeField] Image healthBarImg;

    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        healthBarImg.fillAmount = currentHP / maxHP;

        if (currentHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    public void ModifyHealth(float deltaHP)
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
