using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICannon : Cannon
{
    float time = 3f;
    Transform playerTransform;

    private void Start()
    {
        var players = FindObjectsOfType<Cannon>();
        foreach (var player in players)
        {
            if (player != this)
            {
                playerTransform = player.GetComponent<Transform>();
            }
        }
    }

    public override Vector2 GetInitialVelocity()
    {
        float v0x = (playerTransform.position.x - transform.position.x) / time;
        float v0y = ((playerTransform.position.y - transform.position.y) - 0.5f * Physics2D.gravity.y * time * time) / time;

        // Flip
        var angleY = transform.localEulerAngles.y;
        if ((angleY == 0f && v0x < 0f) || (angleY == 180f && v0x > 0f))
        {
            transform.Rotate(0f, 180f, 0f);
        }

        // Change cannon angle
        float angleDeg = Mathf.Atan(Mathf.Abs(v0y / v0x)) * Mathf.Rad2Deg;
        cannonTransform.localEulerAngles = new Vector3(0f, 0f, angleDeg);

        // Change power slider value
        powerSlider.value = Mathf.Sqrt(v0x * v0x + v0y * v0y);

        return new Vector2(v0x, v0y);
    }
}
