using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeleeWeapon : Weapon
{
    public float damageRadius;

    public override void Use(WeaponController weaponController)
    {
        Vector3 position = weaponController.weaponPosition.position;

        float length = 1.0f;
        float amount = 360.0f / length;

        float current = 0.0f;
        
        float hyp = damageRadius;
        for (int i = 0; i < amount; ++i)
        {
            float radians = Mathf.Deg2Rad * current;
            float x = Mathf.Cos(radians) * hyp;
            float y = Mathf.Sin(radians) * hyp;
            Vector3 end = new Vector3(x + position.x, y + position.y, 0.0f);
            Debug.DrawLine(position, end, Color.red, 1.0f);

            current += length;
        }
    }
}