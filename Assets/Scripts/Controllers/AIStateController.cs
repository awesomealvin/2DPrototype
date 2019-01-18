using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateController : MonoBehaviour
{
    public Position playerPosition;
    public GlobalStats playerStats;

    public AIStates aiStates;

    [HideInInspector]
    private CircleController circleController;

    [HideInInspector]
    public MovementController movementController;

    [HideInInspector]
    public WeaponController weaponController;

    [HideInInspector]
    public HealthController healthController;

    [HideInInspector]
    public float combatActionDelay;

    [HideInInspector]
    public AIState currentMovementState;

    [HideInInspector]
    public AIState currentLookState;

    [HideInInspector]
    public AIState currentCombatState;

    void OnValidate()
    {
        circleController = GetComponent<CircleController>();

        movementController = circleController.movementController;
        weaponController = circleController.weaponController;
        healthController = circleController.healthController;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }

    public void Initialise()
    {
        currentMovementState = aiStates.followPlayerState;
        currentLookState = aiStates.lookAtState;
        currentCombatState = aiStates.outOfAttackRangeState;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthController.isDead)
        {
            return;
        }
        if (currentMovementState != null)
        {
            currentMovementState.Execute(this);
        }

        if (currentLookState != null)
        {
            currentLookState.Execute(this);
        }

        HandleWeaponStates();

    }


    private void HandleWeaponStates()
    {

        if (currentCombatState == null)
        {
            return;
        }
        currentCombatState.Execute(this);

        if (combatActionDelay >= 0.0f)
        {
            combatActionDelay -= Time.deltaTime;
        }

    }

    public void ChangeCombatState(AIState next)
    {
        currentCombatState.Exit(this);
        currentCombatState = next;
        currentCombatState.Enter(this);
    }

    public void ChangeMovementState(AIState next)
    {
        currentMovementState.Exit(this);
        currentMovementState = next;
        currentMovementState.Enter(this);
    }

    // TODO: Optimize using Vector2.sqrMagnitude
    public float DistanceFromPlayer()
    {
        Vector2 direction = playerPosition.position - transform.position;
        return direction.magnitude;
    }
}