using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Transform climbCheck;
    [SerializeField] private Transform climbGoal;
    [SerializeField] private float fallingSpeed;

    private PlayerMove playerMove;

    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer sr;

    private float movement;
    private bool climbing;
    private bool crouching;

    private float climbCheckX;
    private float climbGoalX;

    private bool canTurn;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        climbCheckX = climbCheck.localPosition.x;
        climbGoalX = climbGoal.localPosition.x;

        playerMove = GetComponent<PlayerMove>();

        canTurn = true;
    }

    private void Update()
    {
        if (animator != null)
        {
            if (body.velocity.y < -fallingSpeed) animator.SetBool("Falling", true);
            else animator.SetBool("Falling", false);
        }
    }

    public void SetMovement(float movement)
    {
        this.movement = movement;

        if (movement != 0)
        {
            if (animator != null)
                animator.SetBool("Walking", true);
            if (canTurn)
            {
                if (movement > 0)
                {
                    if (sr != null)
                        sr.flipX = false;
                    if (climbCheck != null)
                        climbCheck.localPosition = new Vector3(climbCheckX, climbCheck.localPosition.y, 0f);
                    if (climbGoal != null)
                        climbGoal.localPosition = new Vector3(climbGoalX, climbGoal.localPosition.y, 0f);
                }
                else
                {
                    if (sr != null)
                        sr.flipX = true;
                    if (climbCheck != null)
                        climbCheck.localPosition = new Vector3(-climbCheckX, climbCheck.localPosition.y, 0f);
                    if (climbGoal != null)
                    {
                        climbGoal.localPosition = new Vector3(-climbGoalX, climbGoal.localPosition.y, 0f);
                        climbGoal.localPosition = new Vector3(-climbGoalX, climbGoal.localPosition.y, 0f);
                    }
                }
            }
        } else
        {
            if (animator != null)
            animator.SetBool("Walking", false);
        }
    }

    public void SetClimbing(bool climbing)
    {
        this.climbing = climbing;

        if (animator != null)
            if (climbCheck.gameObject.GetComponent<LedgeDetection>().GetCanClimb() && this.climbing)
            {
                animator.SetBool("Climbing", true);
                playerMove.SetCanMove(false);
                canTurn = false;
            }
            else animator.SetBool("Climbing", false);
    }

    public void SetCanTurn(bool canTurn)
    {
        this.canTurn = canTurn;
    }

    public void ResetTurn()
    {
        SetMovement(movement);
    }
}
