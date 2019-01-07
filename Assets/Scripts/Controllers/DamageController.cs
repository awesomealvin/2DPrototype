using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public MovementController movementController;

    public HealthController healthController;


    public void Damage(int health, Vector2 force, float staggerTime)
    {
        healthController.DeductHealth(health);

        movementController.Stagger(staggerTime);

        movementController.rb.AddForce(force, ForceMode2D.Impulse);
        // Debug.Log(force);
    }
}
