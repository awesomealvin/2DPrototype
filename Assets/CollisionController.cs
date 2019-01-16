using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField]
    AbilityController abilityController;

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (abilityController != null)
        {
            abilityController.CollisionEnter2DEvent(other);
        }
    }
}
