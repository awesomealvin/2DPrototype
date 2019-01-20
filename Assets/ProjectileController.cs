using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : RespawnableObject
{
    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public int damage;

    [HideInInspector]
    public float duration;

    [HideInInspector]
    public Transform owner;

    [HideInInspector]
    public float force;

    public EntityType entityType;

    public ProjectileObjectPool objectPool;

    public override void Initialise()
    {
        rb.velocity = Vector2.zero;
    }

    public void Initialise(int damage, float duration, float force, Transform owner)
    {
        Initialise();
        this.damage = damage;
        this.duration = duration;
        this.owner = owner;
        this.force = force;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdateDuration();
    }

    private void UpdateRotation()
    {
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void UpdateDuration()
    {
        duration -= Time.deltaTime;
        if (duration <= 0.0f)
        {
            // ObjectPool.instance.AddProjectileToQueue(this);
            objectPool.Add(this);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Touched: " +other.name);

        if (other.transform.parent == owner)
        {
            // Debug.Log("Tocuhed Owner");
            return;
        }
        if (other.transform.parent.gameObject.CompareTag("Circle"))
        {
            // Debug.Log("Touched other");

            CircleController circleController = other.transform.parent.GetComponent<CircleController>();
            if (circleController != null)
            {
                HealthController healthController = circleController.healthController;
                if (healthController != null)
                {
                    Vector2 direction = transform.position - healthController.transform.position;
                    Vector2 newForce = direction * force;
                    healthController.Damage(damage, -newForce, 1.0f, this.entityType);
                }
            }

            objectPool.Add(this);
            gameObject.SetActive(false);

        }
    }
}