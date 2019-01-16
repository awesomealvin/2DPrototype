using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public MovementController movementController;

    public HealthController healthController;

    // [SerializeField]
    // private ParticleType onDamageParticleType;


    [SerializeField]
    private ParticleSystemController onHitDamageParticles;


    public void Damage(int health, Vector2 force, float staggerTime)
    {
        healthController.DeductHealth(health);

        movementController.Stagger(staggerTime);

        movementController.rb.AddForce(force, ForceMode2D.Impulse);
        // Debug.Log(force);

        // Apply particle effects
        if (onHitDamageParticles != null)
        {
            onHitDamageParticles.Play();
        }
    }
}
