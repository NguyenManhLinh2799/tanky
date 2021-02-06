﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var aiMove = collision.GetComponent<AIMove>();
        if (aiMove != null)
        {
            aiMove.randomDirection = -aiMove.randomDirection;
        }
    }
}
