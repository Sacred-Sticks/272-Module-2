using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private Rigidbody2D connectedBody;
    private GameObject obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weight" || collision.tag == "Player" || collision.tag == "Piston")
        {
            SetWeighted(collision.gameObject, true);
            connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            connectedBody.gravityScale = 0;
        } else
        {
            obj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetWeighted(collision.gameObject, false);
        if (connectedBody != null)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() == connectedBody)
            {
                connectedBody.gravityScale = 1;
                connectedBody = null;
            }
        } else
        {
            obj = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
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

    private void SetWeighted(GameObject obj, bool weighted)
    {
        if (obj.GetComponent<WeightedObject>() != null)
        {
            WeightedObject connectedWeight = obj.GetComponent<WeightedObject>();
            connectedWeight.SetIsWeighted(weighted);
        }
    }

    public Rigidbody2D GetConnectedBody()
    {
        return connectedBody;
    }

    public GameObject GetConnectedStructure()
    {
        return obj;
    }
}
