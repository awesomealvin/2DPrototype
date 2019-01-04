using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Movement movement;
    public Position position;

    [HideInInspector]
    public MovementState currentMovementState;

    public MovementStates movementStates;

    [HideInInspector]
    public float staggerTime; // Temporary? Should it stay here, or in it's own state instance?

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = movement.linearDrag;
        movement.currentVelocity = Vector2.zero;
        currentMovementState = movementStates.movingState;
        currentMovementState.Enter(this);

    }

    // Update is called once per frame
    void Update()
    {
        movement.currentVelocity = rb.velocity;
        if (position != null)
        {
            position.position = transform.position;
        }

        currentMovementState.Execute(this);
    }

    public void Move(Vector2 direction)
    {
        rb.drag = movement.linearDrag;

        direction = Vector2.ClampMagnitude(direction, 1.0f);

        Vector2 force = direction * movement.acceleration;

        rb.AddForce(force, ForceMode2D.Impulse);

        if (rb.velocity.magnitude > movement.maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * movement.maxSpeed;
        }
    }

    public void MoveUp()
    {
        currentMovementState.MoveUp(this);
    }
    public void MoveDown()
    {
        currentMovementState.MoveDown(this);

    }
    public void MoveLeft()
    {
        currentMovementState.MoveLeft(this);

    }
    public void MoveRight()
    {
        currentMovementState.MoveRight(this);
    }

    public void ChangeState(MovementState newState)
    {
        currentMovementState.Exit(this);
        currentMovementState = newState;
        newState.Enter(this);
    }

}