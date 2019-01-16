using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParticleType : ScriptableObject
{
    public enum ParticleTypes
    {
        MELEE_PLAYER, FISTER_ON_HIT
    }

    public ParticleTypes particleType;
}
