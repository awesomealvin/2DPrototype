using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Health States/Alive")]
public class AliveState : HealthState
{
    public override void Enter(HealthController healthController)
    {
        // healthController.Initialise();
        healthController.circleRender.SetActive(true);
    }

    public override void Execute(HealthController healthController)
    { }

    public override void Exit(HealthController healthController)
    {

    }

}