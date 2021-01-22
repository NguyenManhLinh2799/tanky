using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScaler : MonoBehaviour
{
    [SerializeField] float scaleTimes = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;
        if (other.tag == "Projectile")
        {
            var newX = other.transform.localScale.x * scaleTimes;
            var newY = other.transform.localScale.y * scaleTimes;
            other.transform.localScale = new Vector3(newX, newY, other.transform.localScale.z);
            other.GetComponent<Projectile>().damage *= scaleTimes;
        }
    }
}
