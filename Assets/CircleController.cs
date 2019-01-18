using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(AbilityController))]
public class CircleController : MonoBehaviour
{
    public HealthController healthController;
    public MovementController movementController;
    public WeaponController weaponController;
    public AbilityController abilityController;

    public AIStateController aiStateController;

    public CircleObjectPool objectPool;

    public void Initialise(Vector2 position)
    {
        transform.position = position;
        healthController.Initialise();

        movementController.Initialise();

        if (aiStateController != null)
        {
            aiStateController.Initialise();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (abilityController != null)
        {
            abilityController.CollisionEnter2DEvent(other);
        }
    }
}