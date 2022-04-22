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
    private Rigidbody2D leftConnectedBody;
    private Rigidbody2D rightConnectedBody;

    bool leftUp, leftDown, rightUp, rightDown;
    [SerializeField] bool pulleyLock;

    void Start()
    {
        leftBody = leftPlatform.GetComponent<Rigidbody2D>();
        rightBody = rightPlatform.GetComponent<Rigidbody2D>();
        leftBody.gravityScale = 0;
        rightBody.gravityScale = 0;
        leftBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rightBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        GetConnectedBodies();
        if (!pulleyLock && (leftConnectedBody != null || rightConnectedBody != null))
        {
            //Debug.Log("Connected");
            SetMovability();
            float massDiff = GetMassDifference();
            SetVelocities(massDiff);

            if (leftConnectedBody != null)
            {
                //Debug.Log(leftConnectedBody.gameObject.name);
            }
            if (rightConnectedBody != null)
            {
                //Debug.Log(rightConnectedBody.gameObject.name);
            }
            
            //Debug.Log("Mass Difference is " + massDiff);

            if (massDiff > 0 && (rightDown && leftUp))
            {
                //Debug.Log("Moving Right");
                SetVelocities(-massDiff);
            }
            else if (massDiff < 0 && (rightUp && leftDown))
            {
                SetVelocities(-massDiff);
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

    private void GetConnectedBodies()
    {
        leftConnectedBody = leftPlatform.GetComponent<CollisionDetection>().GetConnectedBody();
        rightConnectedBody = rightPlatform.GetComponent<CollisionDetection>().GetConnectedBody();
    }

    private void SetMovability()
    {
        leftUp = CheckTop(leftPlatform.transform, leftPulley.transform);
        leftDown = CheckBottom(leftPlatform, leftConnectedBody);
        rightUp = CheckTop(rightPlatform.transform, rightPulley.transform);
        rightDown = CheckBottom(rightPlatform, rightConnectedBody);
    }

    private bool CheckBottom(GameObject platform, Rigidbody2D connectedBody)
    {
        GameObject obj = platform.GetComponent<CollisionDetection>().GetConnectedStructure();
        if (obj == null) {
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
        if (rightConnectedBody != null)
        {
            diff = rightConnectedBody.mass;
            if (leftConnectedBody != null)
            {
                diff -= leftConnectedBody.mass;
            }
        }
        else
        {
            diff = -leftConnectedBody.mass;
        }
        return diff;
    }

    private void SetVelocities(float massDiff)
    {
        massDiff *= multiplier;
        rightBody.velocity = new Vector2(0, massDiff);
        leftBody.velocity = -rightBody.velocity;
        if (rightConnectedBody != null) rightConnectedBody.velocity = new Vector2(rightConnectedBody.velocity.x, rightBody.velocity.y);
        if (leftConnectedBody != null) leftConnectedBody.velocity = new Vector2(leftConnectedBody.velocity.x, leftBody.velocity.y);
    }
    private void SetPulleyLock(bool pulleyLock)
    {
        this.pulleyLock = pulleyLock;
    }
}
