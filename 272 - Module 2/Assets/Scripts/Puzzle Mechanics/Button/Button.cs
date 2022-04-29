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
    private bool buttonChanged;

    void Start()
    {
        originalPosition = transform.position;
        buttonActive = false;
        buttonReleased.Invoke();
        collisionDetection = GetComponent<CollisionDetection>();
    }

    void Update()
    {
        bodies = collisionDetection.GetConnectedBodies();
        if (bodies.Count == 0 && buttonActive)
        {
            transform.position = originalPosition;
            buttonActive = false;
            StopAllCoroutines();
            buttonChanged = true;
        } else if (bodies.Count > 0 && !buttonActive)
        {
            buttonActive = true;
            buttonChanged = true;
            StartCoroutine("lowerButton");
        }

        if (buttonActive && buttonChanged)
        {
            buttonPressed.Invoke();
            buttonChanged = false;
        } else if (buttonChanged)
        {
            buttonReleased.Invoke();
            buttonChanged = false;
        }
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
    }
}
