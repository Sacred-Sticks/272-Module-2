using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Transform climbingLocation;
    [SerializeField] private float fallingSpeed;

    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer sr;

    private float movement;
    private bool climbing;
    private bool crouching;

    private float climbLocationX;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        climbLocationX = climbingLocation.position.x;
    }

    private void Update()
    {
        if (body.velocity.y < -fallingSpeed) animator.SetBool("Falling", true);
        else animator.SetBool("Falling", false);
    }

    public void SetMovement(float movement)
    {
        this.movement = movement;

        if (movement != 0)
        {
            animator.SetBool("Walking", true);
            if (movement > 0)
            {
                sr.flipX = false;
                climbingLocation.localPosition = new Vector3(0.4f, climbingLocation.localPosition.y, 0f);
            }
            else
            {
                sr.flipX = true;
                climbingLocation.localPosition = new Vector3(-0.4f, climbingLocation.localPosition.y, 0f);
            }
        } else
        {
            animator.SetBool("Walking", false);
        }
    }

    public void SetClimbing(bool climbing)
    {
        this.climbing = climbing;

        if (climbingLocation.gameObject.GetComponent<LedgeDetection>().GetCanClimb() && this.climbing)
            animator.SetBool("Climbing", true);
        else animator.SetBool("Climbing", false);
    }

    public void SetCrouching(bool crouching)
    {
        this.crouching = crouching;

        animator.SetBool("Crouching", crouching);
    }
}
