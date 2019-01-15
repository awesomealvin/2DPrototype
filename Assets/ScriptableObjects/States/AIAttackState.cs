using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI States/Combat/Attack State")]
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
        if (aiStateController.combatActionDelay <= 0.0f)
        {
            WeaponController weaponController = aiStateController.weaponController;
            weaponController.Use();

            if (aiStateController.DistanceFromPlayer() > weaponController.weapon.range)
            {
                aiStateController.ChangeCombatState(aiStateController.aiStates.outOfAttackRangeState);
            }
        }
    }

    public override void Exit(AIStateController aiStateController)
    {

    }

}