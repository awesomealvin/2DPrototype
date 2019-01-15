using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateController : MonoBehaviour
{
    public Position playerPosition;
    public GlobalStats playerStats;

    public AIStates aiStates;

    public MovementController movementController;
    
    public float combatActionDelay;

    [HideInInspector]
    public AIState currentMovementState;

    [HideInInspector]
    public AIState currentLookState;

    [HideInInspector]
    public AIState currentCombatState;

    // Start is called before the first frame update
    void Start()
    {
        currentMovementState = aiStates.followPlayerState;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMovementState != null)
        {
            currentMovementState.Execute(this);
        }

        if (currentLookState != null)
        {
            currentLookState.Execute(this);
        }
    }
}
