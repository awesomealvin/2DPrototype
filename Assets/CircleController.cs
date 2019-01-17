using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public HealthController healthController;

    public AIStateController aiStateController;

    public MovementController movementController;

    public void Initialise(Vector2 position)
    {
        transform.position = position;
        healthController.Initialise();

        movementController.Initialise();

        if (aiStateController != null)
        {
            aiStateController.Initialise();
        }
    }
}