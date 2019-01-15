using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AILookAtState : AIState
{
    public float lookSpeed;

    public override void Enter(AIStateController aiStateController)
    {

    }

    public override void Execute(AIStateController aiStateController)
    {
        RotationController rotationController = aiStateController.rotationController;

        Vector2 desiredLookDirection = 
            aiStateController.playerPosition.position;
        Vector2 currentLookDirection = rotationController.lookDirection;

        float desiredLookAngle = Mathf.Atan2(desiredLookDirection.y, desiredLookDirection.x);
        float currentLookAngle = Mathf.Atan2(currentLookDirection.y, currentLookDirection.x);
    

        Debug.Log("DesiredAngle: " + desiredLookAngle * Mathf.Rad2Deg + " | CurrentAngle: " + currentLookAngle* Mathf.Rad2Deg);
        // Debug.Log("AI Position: " + aiStateController.transform.position);
        // Debug.Log("Player Position: " + aiStateController.playerPosition.position);

        float newLookAngle = Mathf.Lerp(currentLookAngle, desiredLookAngle, lookSpeed * Time.deltaTime);

        float x = Mathf.Cos(newLookAngle);
        float y = Mathf.Sin(newLookAngle);


        rotationController.lookDirection = new Vector2(x, y);

    }

    public override void Exit(AIStateController aiStateController)
    {

    }
}