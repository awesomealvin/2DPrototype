using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public float cooldown;
    public abstract void Use(AbilityController abilityController);
    public abstract void Execute(AbilityController abilityController);
}
