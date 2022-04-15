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

    private Rigidbody2D connectedBody;
    private Vector3 originalPosition;

    [SerializeField] private bool buttonActive;

    void Start()
    {
        originalPosition = transform.position;
        buttonActive = false;
        buttonReleased.Invoke();
    }

    void Update()
    {
        connectedBody = GetComponent<CollisionDetection>().GetConnectedBody();

        if (connectedBody == null && buttonActive)
        {
            transform.position = originalPosition;
            buttonReleased.Invoke();
            buttonActive = false;
        } else if (connectedBody != null && !buttonActive)
        {
            buttonActive = true;
            connectedBody.gameObject.transform.parent = transform;
            transform.position = originalPosition - transform.up * heightModifier;
            connectedBody.gameObject.transform.parent = null;
            buttonPressed.Invoke();
            connectedBody.gravityScale = 1;
        }
    }
}
