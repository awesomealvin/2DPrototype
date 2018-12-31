using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Movement movement;
    public Position position;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.currentVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        movement.currentVelocity = rb.velocity;
        if (position != null)
        {
            position.position = transform.position;

        }
    }

    public void Move(Vector2 direction)
    {
        rb.drag = movement.linearDrag;

        direction = Vector2.ClampMagnitude(direction, 1.0f);

        Vector2 force = direction * movement.acceleration;
        Debug.Log(movement.acceleration);

        rb.AddForce(force, ForceMode2D.Impulse);

        if (rb.velocity.magnitude > movement.maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * movement.maxSpeed;
        }
    }

    public void MoveUp()
    {
        Move(new Vector2(0.0f, 1.0f));
    }

    public void MoveDown()
    {
        Move(new Vector2(0.0f, -1.0f));

    }

    public void MoveRight()
    {
        Move(new Vector2(1.0f, 0.0f));

    }

    public void MoveLeft()
    {
        Move(new Vector2(-1.0f, 0.0f));
    }
}