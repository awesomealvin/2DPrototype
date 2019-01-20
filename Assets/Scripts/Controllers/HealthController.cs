using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [HideInInspector]
    public CircleController circleController;

    public IntegerVariable maxHealth;

    protected int currentHealth;

    public bool isDead;

    [HideInInspector]
    public float currentDeathTimer;

    private HealthState currentHealthState;
    public HealthState aliveState;
    public HealthState deathState;

    public GameObject circleRender;

    [HideInInspector]
    public bool isPlayer;

    [SerializeField]
    private ParticleSystemController onHitDamageParticles;

    [SerializeField]
    protected GameOnHitEvent onHitEvent;

    [SerializeField]
    protected GameEvent onDeathEvent;

    void OnValidate()
    {
        circleController = GetComponent<CircleController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialise();
        SetAliveState();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthState.Execute(this);
    }

    public virtual void DeductHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f && !isDead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        if (!isDead)
        {
            SetDeathState();
            if (onDeathEvent != null)
            {
                onDeathEvent.Raise();
                Debug.Log("On Death Raised");

            }
        }

        isDead = true;
    }

    public void Initialise()
    {
        // Debug.Log("HealthCotroller INitialised");
        currentHealth = maxHealth.value;
        isDead = false;
        SetAliveState();

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

    public virtual void Damage(int health, Vector2 force, float staggerTime, EntityType attacker)
    {
        OnHitData onHitData = new OnHitData();
        onHitData.currentHealth = currentHealth;
        onHitData.damageAmount = health;
        onHitData.attacker = attacker;
        onHitEvent.Raise(onHitData);

        DeductHealth(health);

        MovementController movementController = circleController.movementController;

        movementController.Stagger(staggerTime);

        movementController.rb.AddForce(force, ForceMode2D.Impulse);
        // Debug.Log(force);

        // Apply particle effects
        if (onHitDamageParticles != null)
        {
            onHitDamageParticles.Play();
        }
    }

    public void Suicide()
    {
        if (!isDead)
        {
            Damage(99999, new Vector2(0, 0), 0.0f, circleController.entityType); 
        }
    }

}