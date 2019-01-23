using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/ENemy Stats")]
public class EnemyStats : ScriptableObject
{
    public int maxHealth;
    public float movementSpeed;
    public float attackRange;
    public float disengageRange;
}
