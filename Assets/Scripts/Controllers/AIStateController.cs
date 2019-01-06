using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateController : MonoBehaviour
{
    public Position playerPosition;

    public AIStates aiStates;

    public MovementController movementController;

    [HideInInspector]
    public AIState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = aiStates.followPlayerState;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }
}
