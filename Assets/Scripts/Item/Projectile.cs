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

    [SerializeField] protected AudioClip fireSound;
    [SerializeField] protected AudioClip impactSound;
    protected AudioSource audioSource;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gamePhase = FindObjectOfType<GamePhase>();
        gamePhase.WaitProjectileToBeLanded();

        playerThatShootThis = gamePhase.playerThatIsInTurn;

        audioSource = GetComponent<AudioSource>();

        IgnorePlayerCollision();
        SetInitialVelocity();

        PlayShootEffect();
    }

    protected virtual void Update()
    {
        if (!isLanded)
        {
            Vector2 dir = transform.GetComponent<Rigidbody2D>().velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    protected void PlayShootEffect()
    {
        if (fireSound != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
        
        playerThatShootThis.GetComponent<Cannon>().PlayShootEffect();
    }

    protected void SetInitialVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = playerThatShootThis.GetComponent<Cannon>().GetInitialVelocity();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (impactSound != null)
        {
            AudioSource.PlayClipAtPoint(impactSound, transform.position);
        }
        
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
