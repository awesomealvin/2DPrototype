using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AIFollowState : AIState
{
    public override void Enter(AIStateController aiStateController)
    {
    }

    public override void Execute(AIStateController aiStateController)
    {
        Vector2 direction = aiStateController.playerPosition.position - aiStateController.transform.position;
        aiStateController.movementController.Move(direction);
    }

    public override void Exit(AIStateController aiStateController)
    {
    }
}
