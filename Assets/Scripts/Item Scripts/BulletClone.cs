using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletClone : MonoBehaviour
{
    // Config params
    [SerializeField] GameObject VFX;
    [SerializeField] float damage = 15f;

    // Cached references
    Bullet bullet;

    // State variables
    Vector2 initialVelocity;

    void Start()
    {
        bullet = FindObjectOfType<Bullet>();
        initialVelocity = bullet.GetInitialVelocity();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
            bullet.GetPlayerThatShootThis().GetComponent<Collider2D>());

        GetComponent<Rigidbody2D>().velocity = initialVelocity;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(VFX, transform.position, transform.rotation);
        explosion.transform.localScale = new Vector3(
            explosion.transform.localScale.x * transform.localScale.x,
            explosion.transform.localScale.y * transform.localScale.y,
            0f);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
