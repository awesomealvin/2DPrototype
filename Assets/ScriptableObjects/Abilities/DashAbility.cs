﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashForce;

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

    }

    public override void Use(AbilityController abilityController)
    {

        abilityController.rb.velocity = Vector2.zero;
        // Change Movement State
        MovementController movementController = abilityController.movementController;
        if (movementController != null)
        {
            movementController.Stagger(1.0f);
        }

        Rigidbody2D rb = abilityController.rb;

        Vector2 force = abilityController.useDirection.normalized * dashForce;
        rb.AddForce(-force, ForceMode2D.Impulse);

        abilityController.PlayParticles();

    }
}