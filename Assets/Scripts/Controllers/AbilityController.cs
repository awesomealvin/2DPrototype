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
    public CircleController circleController;

    [SerializeField]
    public ParticleSystemController particleSystemController;

    void OnValidate()
    {
        circleController = GetComponent<CircleController>();
    }

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        // duration = 0.0f;
    }

    public void UseAbility()
    {
        if (currentCooldown <= 0.0f)
        {
            if (!inUse)
            {
                duration = ability.duration;
                currentCooldown = ability.cooldown;
                useDirection = -transform.right;
                ability.Use(this);
                inUse = true;

                // Debug.Log("Used Ability");
            }
        }
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;

        // Execution (overtime)
        if (inUse)
        {
            ability.Execute(this);

            duration -= Time.deltaTime;

            if (duration <= 0.0f)
            {
                ability.Exit(this);
                inUse = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (inUse)
        {
            ability.ExecuteFixed(this);
        }
    }

    public void CollisionEnter2DEvent(Collision2D other)
    {
        if (!inUse)
        {
            return;
        }
        if (ability != null)
        {
            ability.OnCollisionEnterEvent(this, other);
        }
    }

    public void PlayParticles()
    {
        if (particleSystemController != null)
        {
            particleSystemController.Play();
        }

    }

    public void StopParticles()
    {
        if (particleSystemController != null)
        {
            particleSystemController.Stop();
        }
    }

}