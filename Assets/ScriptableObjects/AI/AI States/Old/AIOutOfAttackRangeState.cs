using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI States/Combat/Out of Attack Range")]
public class AIOutOfAttackRangeState : AIState
{

    public float attackRange;

    public override void Enter(AIStateController aiStateController)
    {

    }

    public override void Execute(AIStateController aiStateController)
    {
        if (aiStateController.DistanceFromPlayer() <= attackRange)
        {
            // Debug.Log("Changed State");
            aiStateController.ChangeCombatState(aiStateController.aiStates.attackState);
        }
    }

    public override void Exit(AIStateController aiStateController)
    {

    }

}