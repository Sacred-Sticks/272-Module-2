using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D body;

    private float movement;
    private bool climbing;
    private bool crouching;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (body.velocity.y < 0) animator.SetBool("Falling", true);
        else animator.SetBool("Falling", false);
    }

    public void SetMovement(float movement)
    {
        this.movement = movement;

        if (movement != 0)
        {
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }
    }

    public void SetClimbing(bool climbing)
    {
        this.climbing = climbing;

        animator.SetBool("Climbing", climbing);
    }

    public void SetCrouching(bool crouching)
    {
        this.crouching = crouching;

        animator.SetBool("Crouching", crouching);
    }
}
