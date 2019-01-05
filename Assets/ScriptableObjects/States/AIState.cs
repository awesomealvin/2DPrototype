using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : ScriptableObject
{
    public abstract void Enter(AIStateController aiStateController);
    public abstract void Execute(AIStateController aiStateController);
    public abstract void Exit(AIStateController aiStateController);
}
