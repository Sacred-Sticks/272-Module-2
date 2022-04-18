using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private Rigidbody2D connectedBody;

    private float initialGravityScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            initialGravityScale = connectedBody.gravityScale;
            connectedBody.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (connectedBody != null)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() == connectedBody)
            {
                connectedBody.gravityScale = 1;
                connectedBody = null;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (connectedBody != null)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() == connectedBody)
            {
                connectedBody.gravityScale = initialGravityScale;
                connectedBody = null;
            }
        }
    }

    public Rigidbody2D GetConnectedBody()
    {
        return connectedBody;
    }
}
