using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    MovementState currentMovementState;

    public enum MovementStates
    {
        STATIONARY, MOVING, STAGGERED
    }

    [SerializeField]
    float maxMovementSpeed = 5f;

    Rigidbody2D rb;

    Vector2 lastDirection;

    [HideInInspector]
    public float horizontal = 0.0f;
    [HideInInspector]
    public float vertical = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMovementState.Execute(this);
    }

    void FixedUpdate()
    {

        HandleMovement();

        DebugVelocity();
    }

    public void ChangeState(MovementState movementState)
    {
        currentMovementState = movementState;
        currentMovementState.Enter(this);
    }

    void HandleMovement()
    {
        Vector2 currentVelocity = rb.velocity;

        Debugger.GetInstance().SetDebugText(1, "Horizontal: " + horizontal);
        Debugger.GetInstance().SetDebugText(2, "Vertical: " + vertical);

        Vector2 direction = new Vector2(horizontal, vertical);
        Vector3 velocity = Vector3.ClampMagnitude(direction, 1.0f);
        // velocity.x *= 0.2f;
        // velocity.y *= 0.2f;

        // float velocityX = velocity.x - currentVelocity.x;
        // float velocityY = velocity.y - currentVelocity.y;

        // Vector2 newVelocity = new Vector2(velocityX, velocityY);
        // lastDirection = newVelocity.normalized;
        // rb.velocity = velocity * maxMovementSpeed;
        rb.AddForce(velocity, ForceMode2D.Impulse);
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            if (rb.velocity.magnitude > maxMovementSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxMovementSpeed;
            }
        }

    }

    void DebugVelocity()
    {
        Debugger.GetInstance().SetDebugText(0, rb.velocity.magnitude.ToString());
    }
}