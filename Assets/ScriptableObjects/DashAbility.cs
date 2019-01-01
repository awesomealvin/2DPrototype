using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashForce;
    public override void Execute(AbilityController abilityController)
    {
        // This ain't do nothing
    }

    public override void Use(AbilityController abilityController)
    {
        Rigidbody2D rb = abilityController.GetComponent<Rigidbody2D>();
        
    }
}
