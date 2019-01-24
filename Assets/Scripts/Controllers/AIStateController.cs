using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateController : MonoBehaviour
{
    public Position playerPosition;
    public GlobalStats playerStats;

    [HideInInspector] private CircleController circleController;

    [HideInInspector] public MovementController movementController;

    [HideInInspector] public WeaponController weaponController;

    [HideInInspector] public HealthController healthController;

    [HideInInspector] public float combatActionDelay;

    public AIStats aiStats;
    public State currentState;
    public State remainState;

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
     
    }

    // Update is called once per frame
    void Update()
    {
        if (healthController.isDead)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.ExecuteState(this);
        }
        if (combatActionDelay >= 0.0f)
        {
            combatActionDelay -= Time.deltaTime;
        }
    }



    // TODO: Optimize using Vector2.sqrMagnitude
    public float DistanceFromPlayer()
    {
        Vector2 direction = playerPosition.position - transform.position;
        return direction.magnitude;
    }

    public bool InRange(Vector2 a, Vector2 b, float range)
    {
        Vector2 direction = b - a;

        bool value = false;
        if (Vector2.SqrMagnitude(direction) <= range * range)
        {
            value = true;
        }
        else
        {
            value = false;
        }

        return value;
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;

        }
    }
}