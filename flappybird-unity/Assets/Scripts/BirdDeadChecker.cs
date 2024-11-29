using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeadChecker : MonoBehaviour
{
    public bool IsDead { get; private set; } = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsDead) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Bird collided with " + collision.gameObject.name);
            IsDead = true;
        }
    }
}

