using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementState
{
    public abstract void Enter(Movement movement);
    public abstract void Execute(Movement movement);
    public abstract void FixedExecute(Movement movement);
    public abstract void Exit(Movement movement);
}
