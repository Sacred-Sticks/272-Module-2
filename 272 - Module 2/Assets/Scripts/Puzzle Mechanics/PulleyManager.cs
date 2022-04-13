using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyManager : MonoBehaviour
{
    [SerializeField] private GameObject firstPlatform;
    [SerializeField] private GameObject secondPlatform;

    private Rigidbody2D firstBody;
    private Rigidbody2D secondBody;

    private float initialGravity;
    private float prevFirstHeight;
    private float prevSecondHeight;
    private float firstHeight;
    private float secondHeight;

    private bool firstTop;
    private bool secondTop;

    // Start is called before the first frame update
    void Start()
    {
        firstBody = firstPlatform.GetComponent<Rigidbody2D>();
        secondBody = secondPlatform.GetComponent<Rigidbody2D>();
        firstBody.gravityScale = 0;
        secondBody.gravityScale = 0;
        firstBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        secondBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        initialGravity = firstBody.gravityScale;
        prevFirstHeight = firstPlatform.transform.position.y;
        prevSecondHeight = secondPlatform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        firstHeight = firstPlatform.transform.position.y;
        secondHeight = secondPlatform.transform.position.y;
        firstTop = getTopStatus(firstPlatform);
        secondTop = getTopStatus(secondPlatform);
        if (firstTop) secondBody.constraints = RigidbodyConstraints2D.FreezePosition;
            else secondBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        if (secondTop) firstBody.constraints = RigidbodyConstraints2D.FreezePosition;
            else firstBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        firstBody.freezeRotation = true;
        secondBody.freezeRotation = true;
        if (firstHeight != prevFirstHeight)
        {
            UpdatePlatform(firstPlatform, firstHeight - prevFirstHeight, secondPlatform);
            secondHeight = secondPlatform.transform.position.y;
            prevSecondHeight = secondHeight;
        }
        if (secondHeight != prevSecondHeight)
        {
            UpdatePlatform(secondPlatform, secondHeight - prevSecondHeight, firstPlatform);
            firstHeight = firstPlatform.transform.position.y;
            prevFirstHeight = firstHeight;
        }
        prevFirstHeight = firstHeight;
        prevSecondHeight = secondHeight;
    }

    private bool getTopStatus(GameObject platform)
    {
        return platform.GetComponent<CollisionDetection>().GetCollision();
    }

    private void UpdatePlatform(GameObject platformCheck, float heightChange, GameObject platformMove)
    {
        platformMove.transform.position = new Vector2(platformMove.transform.position.x, platformMove.transform.position.y - heightChange);
    }
}
