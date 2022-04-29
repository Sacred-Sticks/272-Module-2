using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    List<Rigidbody2D> bodies = new List<Rigidbody2D>();
    Rigidbody2D connectedBody;
    GameObject obj = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weight" || collision.tag == "Player" || collision.tag == "Piston")
        {
            if (!bodies.Contains(collision.gameObject.GetComponent<Rigidbody2D>()))
            {
                //Debug.Log("Collision Set to Connected");
                AddBodyToList(collision.gameObject.GetComponent<Rigidbody2D>());
                connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            }
        }
        else if (collision.gameObject.transform.parent && collision.gameObject.transform.parent.tag == "Player")
        {
            //Debug.Log("Collision Set to Connected");
            AddBodyToList(collision.transform.parent.GetComponent<Rigidbody2D>());
            connectedBody = collision.transform.parent.gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            obj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if (bodies.Contains(body))
        {
            body.gravityScale = 1;
            bodies.Remove(body);
            SetWeighted(body.gameObject, false);
        }
        else 
        {
            obj = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if (connectedBody == body)
        {
            connectedBody = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
    }

    private void AddBodyToList(Rigidbody2D body)
    {
        if (!bodies.Contains(body))
        {
            bodies.Add(body);
            SetWeighted(body.gameObject, true);
            body.gravityScale = 0;
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

    public List<Rigidbody2D> GetConnectedBodies()
    {
        return bodies;
    }

    public GameObject GetConnectedStructure()
    {
        return obj;
    }

    public Rigidbody2D GetBody()
    {
        //if (connectedBody != null) Debug.Log(connectedBody.name);
        return connectedBody;
    }
}
