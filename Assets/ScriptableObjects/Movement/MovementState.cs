using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementState : ScriptableObject
{
    public abstract void MoveUp(MovementController movementController);
    public abstract void MoveDown(MovementController movementController);
    public abstract void MoveLeft(MovementController movementController);
    public abstract void MoveRight(MovementController movementController);

    public abstract void Enter(MovementController movementController);
    public abstract void Execute(MovementController movementController);
    public abstract void Exit(MovementController movementController);
}