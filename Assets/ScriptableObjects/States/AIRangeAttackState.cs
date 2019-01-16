using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI States/Combat/Range Attack State")]
public class AIRangeAttackState : AIState
{
    public float actionDelay;

    public float disengageRange;

    public override void Enter(AIStateController aiStateController)
    {
        aiStateController.combatActionDelay = actionDelay;
        aiStateController.ChangeMovementState(aiStateController.aiStates.stationaryState);
    }

    public override void Execute(AIStateController aiStateController)
    {
        WeaponController weaponController = aiStateController.weaponController;

        if (aiStateController.DistanceFromPlayer() > disengageRange)
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
        aiStateController.ChangeMovementState(aiStateController.aiStates.followPlayerState);
    }

}