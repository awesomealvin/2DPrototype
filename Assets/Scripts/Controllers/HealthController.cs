using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public IntegerVariable maxHealth;

    public GlobalStats playerStats;
    
    [HideInInspector]
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeductHealth(int amount)
    {
        currentHealth -= amount;
    }
}
