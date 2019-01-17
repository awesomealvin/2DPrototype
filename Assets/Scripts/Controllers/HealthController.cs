using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public CircleController circleController;

    public IntegerVariable maxHealth;

    public GlobalStats playerStats;

    private int currentHealth;

    public bool isDead;

    public FloatVariable deathTimer;
    public float currentDeathTimer;

    private HealthState currentHealthState;
    public HealthState aliveState;
    public HealthState deathState;

    public GameObject circleRender;

    // Start is called before the first frame update
    void Start()
    {
        Initialise();
        SetAliveState();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats != null)
        {
            playerStats.health = currentHealth;
        }

        currentHealthState.Execute(this);
    }

    public void DeductHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            if (!isDead)
            {
                SetDeathState();
            }

            isDead = true;

        }
    }

    public void Initialise()
    {
        currentHealth = maxHealth.value;
        isDead = false;
    }

    public void SetAliveState()
    {
        currentHealthState = aliveState;
        currentHealthState.Enter(this);
    }

    public void SetDeathState()
    {
        currentHealthState = deathState;
        currentHealthState.Enter(this);
    }

}