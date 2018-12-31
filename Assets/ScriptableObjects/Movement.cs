using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Movement : ScriptableObject
{
    public float acceleration;
    public float maxSpeed;
    public float linearDrag;

    // TODO: Move to PlayerStats scriptable object
    public Vector2 currentVelocity;
}