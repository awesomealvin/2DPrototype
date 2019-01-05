using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashForce;

    public override void Execute(AbilityController abilityController)
    {
 
        // abilityController.duration -= Time.deltaTime;

        Rigidbody2D rb = abilityController.rb;

        Vector2 force = abilityController.useDirection.normalized * dashForce;
        rb.AddForce(-force, ForceMode2D.Impulse);

        
    }

    public override void Exit(AbilityController abilityController)
    {
    }

    public override void Use(AbilityController abilityController)
    {
       
        abilityController.rb.velocity = Vector2.zero;
        // Change Movement State
        MovementController movementController = abilityController.GetComponent<MovementController>();
        if (movementController != null)
        {
            movementController.Stagger(1.0f);
        }

    }
}