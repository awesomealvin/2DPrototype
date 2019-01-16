using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability ability;

    public Rigidbody2D rb;

    private float currentCooldown = -1.0f;
    public float duration;

    public Vector2 useDirection;

    private bool inUse = false;

    [SerializeField]
    public MovementController movementController;

    void Start()
    {
        if (rb == null)
        {
            rb = transform.parent.GetComponent<Rigidbody2D>();
        }
        // duration = 0.0f;
    }

    public void UseAbility()
    {
        if (currentCooldown <= 0.0f)
        {
            if (!inUse)
            {
                ability.Use(this);
                inUse = true;
                duration = ability.duration;
                currentCooldown = ability.cooldown;
                useDirection = -transform.right;
                // Debug.Log("Used Ability");
            }
        }
    }

    void Update()
    {
        duration -= Time.deltaTime;
        currentCooldown -= Time.deltaTime;

        // Execution (overtime)
        if (inUse)
        {
            ability.Execute(this);
        }
        if (duration <= 0.0f)
        {
            ability.Exit(this);
            inUse = false;
        }
    }

    
    public void CollisionEnter2DEvent(Collision2D other)
    {
        if (ability != null)
        {
            ability.OnCollisionEnterEvent(this, other);
        }
    }

    
}