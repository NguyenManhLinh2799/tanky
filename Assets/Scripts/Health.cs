using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected GameObject deathEffect;
    [SerializeField] float maxHP = 100f;
    [SerializeField] float currentHP;
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
        if (currentHP > 100)
        {
            currentHP = 100;
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
