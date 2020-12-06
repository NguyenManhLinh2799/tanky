using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 15f;
    [SerializeField] protected GameObject effectPrefab;
    protected GamePhase gamePhase;
    protected static GameObject playerThatShootThis;

    protected bool isLanded = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
        gamePhase.WaitProjectileToBeLanded();

        playerThatShootThis = gamePhase.playerThatIsInTurn;

        IgnorePlayerCollision();
        SetInitialVelocity();
    }

    protected void SetInitialVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = playerThatShootThis.GetComponent<Cannon>().GetInitialVelocity();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLanded)
        {
            isLanded = true;
            if (collision.gameObject.tag == "Player")
            {
                GameObject player = collision.gameObject;
                player.GetComponent<Health>().ModifyHealth(-damage);
                player.GetComponent<Health>().Hit();
            }
            Instantiate(effectPrefab, transform.position, transform.rotation);
            gamePhase.GoToNextTurn();
        }
        Destroy(gameObject);
    }

    protected virtual void IgnorePlayerCollision()
    {
        Collider2D playerCollider = playerThatShootThis.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);
    }
}
