using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectPoolType : ScriptableObject
{
    public ObjectPoolTypes objectPoolType; 

    public enum ObjectPoolTypes
    {
        FISTER, SHOOTER, PLAYER
    }
}
