using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyManager : MonoBehaviour
{
    [SerializeField] private GameObject leftPlatform;
    [SerializeField] private GameObject rightPlatform;

    [SerializeField] private GameObject leftPulley;
    [SerializeField] private GameObject rightPulley;
    [Space]
    [SerializeField] private float magnitude;
    [SerializeField] private float multiplier;

    private Rigidbody2D leftBody;
    private Rigidbody2D rightBody;
    private List<Rigidbody2D> leftBodies;
    private List<Rigidbody2D> rightBodies;

    bool leftUp, leftDown, rightUp, rightDown;
    bool pulleyLock;

    // Start is called before the first frame update
    void Start()
    {
        leftBody = leftPlatform.GetComponent<Rigidbody2D>();
        rightBody = rightPlatform.GetComponent<Rigidbody2D>();
        leftBody.gravityScale = 0;
        rightBody.gravityScale = 0;
        leftBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rightBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        GetConnectedBodies();
        if (!pulleyLock && (leftBodies.Count != 0 || rightBodies.Count != 0))
        {
            SetMovability();
            float massDiff = GetMassDifference();

            //Debug.Log("Mass Difference is " + massDiff);

            if (massDiff > 0 && (rightDown && leftUp))
            {
                SetVelocities(massDiff);
                //Debug.Log("Moving Right");
            }
            else if (massDiff < 0 && (rightUp && leftDown))
            {
                SetVelocities(massDiff);
                //Debug.Log("Moving Left");
            }
            else
            {
                //Debug.Log("Not Moving");
                SetVelocities(0);
            }
        } else
        {
            SetVelocities(0);
        }
    }

    public void SetPulleyLock(bool pulleyLock)
    {
        this.pulleyLock = pulleyLock;
    }

    private void GetConnectedBodies()
    {
        this.leftBodies = leftPlatform.GetComponent<CollisionDetection>().GetConnectedBodies();
        this.rightBodies = rightPlatform.GetComponent<CollisionDetection>().GetConnectedBodies();
    }

    private void SetMovability()
    {
        leftUp = CheckTop(leftPlatform.transform, leftPulley.transform);
        leftDown = CheckBottom(leftPlatform);
        rightUp = CheckTop(rightPlatform.transform, rightPulley.transform);
        rightDown = CheckBottom(rightPlatform);
    }

    private bool CheckBottom(GameObject platform)
    {
        GameObject obj = platform.GetComponent<CollisionDetection>().GetConnectedStructure();
        if (obj == null) 
        { 
            //Debug.Log(platform.name + "Bottom True"); 
            return true; 
        }
        //Debug.Log(platform.name + "Bottom False");
        return false;
    }

    private bool CheckTop(Transform platform, Transform pulley)
    {
        if (pulley.position.y - platform.position.y > magnitude)
        {
            //Debug.Log(platform.name + " Top True");
            return true;
        }
        //Debug.Log(platform.name + " Top False");
        return false;
    }

    private float GetMassDifference()
    {
        float diff = 0;
        if (rightBodies.Count > 0)
        {
            foreach (var body in rightBodies)
            {
                diff += body.mass;
                Debug.Log("Mass Difference: " + diff);
            }
            if (leftBodies.Count > 0)
            {
                foreach (var body in leftBodies)
                {
                    diff -= body.mass;
                    Debug.Log("Mass Difference: " + diff);
                }
            }
        }
        else
        {
            foreach (var body in leftBodies)
            {
                diff -= body.mass;
                Debug.Log("Mass Difference: " + diff);
            }
        }
        return diff;
    }

    private void SetVelocities(float massDiff)
    {
        Debug.Log("Setting Velocity as " + massDiff + " on " + leftBody.name);
        massDiff *= multiplier;
        rightBody.velocity = new Vector2(rightBody.velocity.x, -massDiff);
        leftBody.velocity = new Vector2(leftBody.velocity.x, massDiff);
        if (rightBodies.Count > 0) foreach (var body in rightBodies)
            {
                body.velocity = new Vector2(body.velocity.x, -massDiff);
            }
        if (leftBodies.Count > 0) foreach (var body in leftBodies)
            {
                body.velocity = new Vector2(body.velocity.x, massDiff);
            }
    }
}
