using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Health States/Death")]
public class DeathState : HealthState
{
    public float deathTime;

    public override void Enter(HealthController healthController)
    {
        healthController.currentDeathTimer = deathTime;
        healthController.circleRender.SetActive(false);

    }

    public override void Execute(HealthController healthController)
    {
        healthController.currentDeathTimer -= Time.deltaTime;
        // Debug.Log(healthController.currentDeathTimer);
        if (healthController.currentDeathTimer <= 0.0f)
        {
            Exit(healthController);
        }
    }

    public override void Exit(HealthController healthController)
    {
        CircleController c = healthController.circleController;
        c.gameObject.SetActive(false);
        c.objectPool.Add(c);

        // if (ObjectPool.instance == null)
        // {
        //     return;
        // }

        // switch (objectPoolType.objectPoolType)
        // {
        //     case ObjectPoolType.ObjectPoolTypes.FISTER:
        //         ObjectPool.instance.AddFisterToPool(healthController.circleController);
        //         break;
        //     case ObjectPoolType.ObjectPoolTypes.SHOOTER:
        //         ObjectPool.instance.AddShooterToPool(healthController.circleController);
        //         break;
        //     default:
        //         break;
        // }

        // healthController.gameObject.SetActive(false);
    }
}