using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Vector2 lookDirection;

    void Update()
    {
        Vector2 direction = lookDirection - (Vector2) transform.position;

        float radians = Mathf.Atan2(direction.y, direction.x);
        float angle = Mathf.Rad2Deg * radians;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
}