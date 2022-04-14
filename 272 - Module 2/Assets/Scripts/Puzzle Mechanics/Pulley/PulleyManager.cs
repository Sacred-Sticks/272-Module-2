using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyManager : MonoBehaviour
{
    [SerializeField] private GameObject firstPlatform;
    [SerializeField] private GameObject secondPlatform;

    [SerializeField] private GameObject firstPulley;
    [SerializeField] private GameObject secondPulley;
    [Space]
    [SerializeField] private float magnitude;
    [SerializeField] private float multiplier;

    private bool first;
    private bool second;

    private Rigidbody2D firstPlatformBody;
    private Rigidbody2D secondPlatformBody;

    private Rigidbody2D firstPlatformCollision;
    private Rigidbody2D secondPlatformCollision;

    // Start is called before the first frame update
    void Start()
    {
        firstPlatformBody = firstPlatform.GetComponent<Rigidbody2D>();
        secondPlatformBody = secondPlatform.GetComponent<Rigidbody2D>();
        firstPlatformBody.gravityScale = 0;
        secondPlatformBody.gravityScale = 0;
        firstPlatformBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        secondPlatformBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        firstPlatformCollision = firstPlatform.GetComponent<CollisionDetection>().GetConnectedBody();
        secondPlatformCollision = secondPlatform.GetComponent<CollisionDetection>().GetConnectedBody();
        float firstMass = 0;
        float secondMass = 0;
        if (firstPlatformCollision != null)
            firstMass = firstPlatformCollision.mass;
        if (secondPlatformCollision != null)
            secondMass = secondPlatformCollision.mass;

        float massDiff = firstMass - secondMass;

        first = false;
        second = false;

        if (firstPulley.transform.position.y - firstPlatform.transform.position.y > magnitude)
            first = true;
        if (secondPulley.transform.position.y - secondPlatform.transform.position.y > magnitude)
            second = true;

        if (first && second)
        {
            secondPlatformBody.velocity = new Vector2(0, massDiff * multiplier);
        }
        else if (first)
        {
            secondPlatformBody.velocity = new Vector2(0, -secondMass * multiplier);
        }
        else if (second)
        {
            secondPlatformBody.velocity = new Vector2(0, firstMass * multiplier);
        }
        else
        {
            secondPlatformBody.velocity = Vector2.zero;
        }
        if (secondPlatformCollision != null) secondPlatformCollision.velocity = new Vector2(secondPlatformCollision.velocity.x, secondPlatformBody.velocity.y);
        firstPlatformBody.velocity = -secondPlatformBody.velocity;
        if (firstPlatformCollision != null) firstPlatformCollision.velocity = new Vector2(firstPlatformCollision.velocity.x, firstPlatformBody.velocity.y);
    }
}
