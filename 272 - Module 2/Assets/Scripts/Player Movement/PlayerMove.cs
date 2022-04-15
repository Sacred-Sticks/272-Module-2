using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody2D body;

    private float movement;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector2 movementVector = new Vector2(movement, body.velocity.y);
            body.velocity = movementVector;
        }
    }

    public void SetMovement(float movement)
    {
        this.movement = movement * movementSpeed;
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
