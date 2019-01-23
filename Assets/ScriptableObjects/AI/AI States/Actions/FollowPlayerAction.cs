using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Follow Player")]
public class FollowPlayerAction : Action
{
    public override void Execute(AIStateController stateController)
    {
        Vector2 direction = stateController.playerPosition.position - stateController.transform.position;
        stateController.movementController.Move(direction);
    }

   
}
