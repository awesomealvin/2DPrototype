using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthState : ScriptableObject
{
    public abstract void Enter(HealthController healthController);
    public abstract void Execute(HealthController healthController);
    public abstract void Exit(HealthController healthController);
}