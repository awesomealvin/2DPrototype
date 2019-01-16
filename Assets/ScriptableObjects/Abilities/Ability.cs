using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public float cooldown;
    public float duration;
    public abstract void Use(AbilityController abilityController);
    public abstract void Execute(AbilityController abilityController);
    public abstract void ExecuteFixed(AbilityController abilityController);
    public abstract void Exit(AbilityController abilityController);
    public abstract void OnCollisionEnterEvent(AbilityController abilityController, Collision2D other);
}
