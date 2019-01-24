using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Enter(AIStateController stateController);
    public abstract void Execute(AIStateController stateController);
}
