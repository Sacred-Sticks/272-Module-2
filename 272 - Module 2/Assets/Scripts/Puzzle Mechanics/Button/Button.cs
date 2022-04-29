using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private UnityEvent buttonPressed;
    [SerializeField] private UnityEvent buttonReleased;
    [Space]
    [SerializeField] private float heightModifier;

    private CollisionDetection collisionDetection;

    private Rigidbody2D connectedBody;
    private List<Rigidbody2D> bodies;
    private Vector3 originalPosition;

    private bool buttonActive;

    void Start()
    {
        originalPosition = transform.position;
        buttonActive = false;
        buttonReleased.Invoke();
        collisionDetection = GetComponent<CollisionDetection>();
    }

    void Update()
    {

        connectedBody = collisionDetection.GetBody();
        bodies = collisionDetection.GetConnectedBodies();
        //if (connectedBody == null && buttonActive)
        //{
        //    //Debug.Log("Button Released");
        //    transform.position = originalPosition;
        //    buttonReleased.Invoke();
        //    buttonActive = false;
        //} else if (connectedBody != null && !buttonActive)
        //{
        //    //Debug.Log("Button Pressed");
        //    buttonActive = true;
        //    connectedBody.gameObject.transform.parent = transform;
        //    transform.position = originalPosition - transform.up * heightModifier;
        //    connectedBody.gameObject.transform.parent = null;
        //    buttonPressed.Invoke();
        //    connectedBody.transform.position = new Vector3(connectedBody.transform.position.x, transform.position.y, connectedBody.transform.position.z);
        //    connectedBody.gravityScale = 1;
        //    Debug.Log("Button Pos: " + transform.position + ". Player Position: " + connectedBody.gameObject.transform.position);
        //}
        if (bodies.Count == 0 && buttonActive)
        {
            transform.position = originalPosition;
            buttonReleased.Invoke();
            buttonActive = false;
            StopAllCoroutines();
        } else if (bodies.Count > 0 && !buttonActive)
        {
            buttonActive = true;
            StartCoroutine("lowerButton");
        }
        Debug.Log(bodies.Count + " " + buttonActive);
    }

    IEnumerator lowerButton()
    {
        yield return new WaitForSeconds(.125f);
        foreach (var body in bodies)
        {
            body.gameObject.transform.parent = transform;
        }
        transform.position = originalPosition - transform.up * heightModifier;
        foreach (var body in bodies)
        {
            body.gameObject.transform.parent = null;
            body.gravityScale = 1;
        }

        buttonPressed.Invoke();
    }
}
