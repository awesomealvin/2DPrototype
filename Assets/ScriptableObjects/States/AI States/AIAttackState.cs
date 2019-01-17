using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI States/Combat/Attack State")]
public class AIAttackState : AIState
{
    public float actionDelay;

    public override void Enter(AIStateController aiStateController)
    {
        Debug.Log("Entered Attack State");
        aiStateController.combatActionDelay = actionDelay;
    }

    public override void Execute(AIStateController aiStateController)
    {
        WeaponController weaponController = aiStateController.weaponController;

        if (aiStateController.DistanceFromPlayer() > weaponController.weapon.range)
        {
            aiStateController.ChangeCombatState(aiStateController.aiStates.outOfAttackRangeState);
        }

        if (aiStateController.combatActionDelay <= 0.0f)
        {
            weaponController.Use();
        }
    }

    public override void Exit(AIStateController aiStateController)
    {

    }

}