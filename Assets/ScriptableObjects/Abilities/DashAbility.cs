using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public int damage;
    public float dashForce;
    public float damageForce;

    public override void Execute(AbilityController abilityController)
    {

        // abilityController.duration -= Time.deltaTime;

    }

    public override void ExecuteFixed(AbilityController abilityController)
    {

    }

    public override void Exit(AbilityController abilityController)
    {
        Debug.Log("Dash Exit");
        abilityController.StopParticles();
    }

    public override void OnCollisionEnterEvent(AbilityController abilityController, Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            CircleController circleController = other.gameObject.GetComponent<CircleController>();
            if (circleController != null)
            {
                HealthController healthController = circleController.healthController;
                if (healthController != null)
                {
                    Vector2 direction = healthController.transform.position - abilityController.transform.position;
                    Vector2 force = direction * damageForce;
                    healthController.Damage(damage, force, 1.0f, abilityController.circleController.entityType);

                    Dash(abilityController, force.normalized, dashForce * 0.75f);
                }
            }



        }
    }

    public override void Use(AbilityController abilityController)
    {
        Vector2 direction = abilityController.useDirection.normalized;
        Dash(abilityController, direction, dashForce);
    }

    private void Dash(AbilityController abilityController, Vector2 direction, float dashForce)
    {
        abilityController.rb.velocity = Vector2.zero;
        // Change Movement State
        MovementController movementController = abilityController.circleController.movementController;
        if (movementController != null)
        {
            movementController.Stagger(1.0f);
        }

        Rigidbody2D rb = abilityController.rb;

        Vector2 force = direction * dashForce;
        rb.AddForce(-force, ForceMode2D.Impulse);

        abilityController.PlayParticles();
    }
}