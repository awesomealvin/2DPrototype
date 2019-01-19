using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthController
{
    public GlobalStats playerStats;
    public GameEvent playerHealthChangeEvent;

    

    public override void DeductHealth(int amount)
    {
        playerHealthChangeEvent.Raise();

        base.DeductHealth(amount);
    }
}