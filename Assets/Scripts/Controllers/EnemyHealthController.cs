using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : HealthController
{
    public GameEvent enemyOnHitEvent;

    public override void Damage(int health, Vector2 force, float staggerTime, EntityType attacker)
    {
        int points = health;
        if (currentHealth - health < 0)
        {
            points += currentHealth - health;
        }

        enemyOnHitEvent.Raise(points);

        base.Damage(health, force, staggerTime, attacker);     
    }


}