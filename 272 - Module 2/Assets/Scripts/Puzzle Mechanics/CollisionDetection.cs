using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private bool collided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.isStatic) {
            collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.isStatic) collided = false;
    }

    public bool GetCollision()
    {
        return collided;
    }
}
