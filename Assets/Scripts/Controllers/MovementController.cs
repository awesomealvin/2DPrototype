using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Movement movement;
    public Position position;

    [HideInInspector]
    public float staggerTime; 
    [HideInInspector]
    public bool isStaggered;

    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        Initialise();
    }

    public void Initialise()
    {
        rb.drag = movement.linearDrag;
        movement.currentVelocity = Vector2.zero;

        staggerTime = 0.0f;
        isStaggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.currentVelocity = rb.velocity;
        if (position != null)
        {
            position.position = transform.position;
        }

        UpdateStagger();

    }

    private void UpdateStagger()
    {
        if (!isStaggered)
        {
            return;
        }
        staggerTime -= Time.deltaTime;
        // Debug.Log(movementController.staggerTime);

        // if ((staggerTime <= 0.0f))
        // {
        //     isStaggered = false;
        // }

        if ((rb.velocity.magnitude < movement.maxSpeed) || (staggerTime <= 0.0f))
        {
            isStaggered = false;
        }
    }

    public void Stagger(float staggerTime)
    {
        this.staggerTime = staggerTime;
        this.isStaggered = true;
    }

    public void Move(Vector2 direction)
    {
        if (isStaggered)
        {
            return;
        }
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