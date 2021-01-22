using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicGateController : MonoBehaviour
{
    public float timeToChange;
    public float speed;
    Rigidbody2D rigidbody2d;
    public bool isHorizontal;
    public bool isLeft;
    float remainingTimeToChange;
    Vector2 direction = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        remainingTimeToChange = timeToChange;
        direction = isHorizontal == false ? Vector2.down : isLeft ? Vector2.left : Vector2.right;
    }


    // Update is called once per frame
    void Update()
    {
        remainingTimeToChange -= Time.deltaTime;
        if(remainingTimeToChange<=0)
        {
            remainingTimeToChange += timeToChange;
            direction *= -1;
        }
    }
    void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);
    }
}
