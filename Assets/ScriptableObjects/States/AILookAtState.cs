using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI States/Look States/Look State")]
public class AILookAtState : AIState
{
    public float lookSpeed;

    public override void Enter(AIStateController aiStateController)
    {

    }

    public override void Execute(AIStateController aiStateController)
    {
        Transform myTransform = aiStateController.transform;
        Vector2 playerPosition = aiStateController.playerPosition.position;
        Vector2 currentPosition = myTransform.position;

        Vector2 direction = (playerPosition - currentPosition).normalized;
        Vector2 currentDirection = myTransform.right.normalized;

        myTransform.right = Vector2.Lerp(currentDirection, direction, lookSpeed * Time.deltaTime);
        

        // Debug.Log(myTransform.right.normalized);

    }

    public override void Exit(AIStateController aiStateController)
    {

    }
}