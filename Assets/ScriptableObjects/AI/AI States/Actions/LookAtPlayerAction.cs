using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Look At Player")]
public class LookAtPlayerAction : Action
{
    public float lookSpeed;

    public override void Enter(AIStateController stateController)
    {

    }
    
    public override void Execute(AIStateController stateController)
    {
        Transform myTransform = stateController.transform;
        Vector2 playerPosition = stateController.playerPosition.position;
        // Debug.Log(playerPosition);
        Vector2 currentPosition = myTransform.position;

        Vector2 direction = (playerPosition - currentPosition).normalized;
        Vector2 currentDirection = myTransform.right.normalized;

        myTransform.right = Vector2.Lerp(currentDirection, direction, stateController.aiStats.lookSpeed * Time.deltaTime);
    }
}