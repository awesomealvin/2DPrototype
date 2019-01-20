using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityType : ScriptableObject
{
    public enum Type
    {
        PLAYER, FISTER, SHOOTER, PROJECTILE
    }

    public Type type;
    public string entityName;
}
