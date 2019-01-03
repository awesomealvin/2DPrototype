using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StaggerState : MovementState
{
    public float maxStaggerTime;

    public override void Enter(MovementController movementController)
    {
        movementController.staggerTime = maxStaggerTime;
        // Debug.Log("Entered StaggerState");
    }

    public override void Execute(MovementController movementController)
    {

        movementController.staggerTime -= Time.deltaTime;
        // Debug.Log(movementController.staggerTime);

        if ((movementController.rb.velocity.magnitude < movementController.movement.maxSpeed) || (movementController.staggerTime <= 0.0f))
        {
            movementController.ChangeState(movementController.movementStates.movingState);
        }
    }

    public override void Exit(MovementController movementController)
    {
        // Nothing yet?
        // Debug.Log("Exited StaggerState");
    }

    public override void MoveDown(MovementController movementController)
    {
        // DO NOTHING BECAUSE STAGGERED
    }

    public override void MoveLeft(MovementController movementController)
    {
        // DO NOTHING BECAUSE STAGGERED
    }

    public override void MoveRight(MovementController movementController)
    {
        // DO NOTHING BECAUSE STAGGERED

    }

    public override void MoveUp(MovementController movementController)
    {
        // DO NOTHING BECAUSE STAGGERED

    }

}