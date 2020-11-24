using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    // Config params
    [Header("Config")]
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected GameObject deathEffect;
    [SerializeField] float maxHP = 100f;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float gasolineConsumptionRates = 0.02f; // Per speed

    [Header("Keys")]
    [SerializeField] protected KeyCode shootKey;
    [SerializeField] protected KeyCode moveLeftKey;
    [SerializeField] protected KeyCode moveRightKey;
    [SerializeField] protected KeyCode activateItem1;
    [SerializeField] protected KeyCode activateItem2;
    [SerializeField] protected KeyCode activateItem3;

    [Header("Items")]
    [SerializeField] protected List<Image> items;

    // Cached references
    protected GamePhase gamePhase;
    protected GameSelection gameSelection;
    protected Image healthBarImg;
    protected Image gasolineBarImg;

    // State variable
    float currentHP;
    public bool isHit;

    protected virtual void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
        gameSelection = FindObjectOfType<GameSelection>();
        
        currentHP = maxHP;
    }

    protected virtual void Update()
    {
        CheckHP();
        if (IsMyTurn())
        {
            Move();
            ActivateItem();
            Shoot();
        }
    }

    public void ActivateItem()
    {
        if (Input.GetKeyDown(activateItem1))
        {
            FindObjectOfType<GamePhase>().ActivateItem(0);
        }
    }

    public abstract bool IsMyTurn();

    public void Shoot()
    {
        if (Input.GetKeyDown(shootKey))
        {
            LaunchBullet();
        }
    }

    public void LaunchBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void Move()
    {
        float deltaX;
        if (Input.GetKey(moveLeftKey) && gasolineBarImg.fillAmount > 0)
        {
            deltaX = -1 * speed * Time.deltaTime;
        }
        else if (Input.GetKey(moveRightKey) && gasolineBarImg.fillAmount > 0)
        {
            deltaX = speed * Time.deltaTime;
        }
        else
        {
            deltaX = 0f;
        }
        gasolineBarImg.fillAmount -= gasolineConsumptionRates * Mathf.Abs(deltaX);
        transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
    }

    private void CheckHP()
    {
        healthBarImg.fillAmount = currentHP / maxHP;
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    public float GetCurrentHP()
    {
        return currentHP;
    }

    public void SetCurrentHP(float hp)
    {
        currentHP = hp;
    }

    public Bullet GetBulletPrefab()
    {
        return bullet;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            isHit = true;
            currentHP -= collision.gameObject.GetComponent<Bullet>().GetDamage();
        }
        else if (collision.gameObject.tag == "Bullet Clone")
        {
            currentHP -= collision.gameObject.GetComponent<BulletClone>().GetDamage();
        }
    }
}
