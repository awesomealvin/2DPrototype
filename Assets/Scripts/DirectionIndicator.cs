using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    [SerializeField]
    AbilityController abilityController;

    void Update()
    {
        RotateIndicator();
    }

    void RotateIndicator()
    {
        if (abilityController != null)
        {
            Vector2 direction = abilityController.lookDirection - (Vector2) transform.position;
            float radians = Mathf.Atan2(direction.y, direction.x);
            float angle = Mathf.Rad2Deg * radians;
            Vector3 rotation = transform.localEulerAngles;
            rotation.z = angle;
            transform.localEulerAngles = rotation;
        }
    }
}
