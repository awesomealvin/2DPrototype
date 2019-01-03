using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovingState : MovementState
{
    
    public override void MoveUp(MovementController movementController)
    {
        movementController.Move(new Vector2(0.0f, 1.0f));
    }

    public override void MoveDown(MovementController movementController)
    {
        movementController.Move(new Vector2(0.0f, -1.0f));

    }

    public override void MoveRight(MovementController movementController)
    {
       movementController.Move(new Vector2(1.0f, 0.0f));

    }

    public override void MoveLeft(MovementController movementController)
    {
       movementController.Move(new Vector2(-1.0f, 0.0f));
    }

    public override void Enter(MovementController movementController)
    {
    }

    public override void Execute(MovementController movementController)
    {
    }

    public override void Exit(MovementController movementController)
    {
    }
}
