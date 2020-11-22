using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    // Config params
    [Header("Config")]
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected GameObject VFX;
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
    protected Image healthBarImg;
    protected Image gasolineBarImg;

    protected virtual void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
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
            FindObjectOfType<GamePhase>().SetPlayerActivatedItem(1);
        }
    }

    public abstract bool IsMyTurn();

    private void Shoot()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
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
        if (healthBarImg.fillAmount <= 0)
        {
            Destroy(gameObject);
            Instantiate(VFX, transform.position, transform.rotation);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthBarImg.fillAmount -= collision.gameObject.GetComponent<Bullet>().GetDamage();
        }
    }
}
