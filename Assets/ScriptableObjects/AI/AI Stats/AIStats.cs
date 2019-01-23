using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Stats")]
public class AIStats : ScriptableObject
{
    public float attackRange;
    public float disengageRange;
    public float lookSpeed;
}
