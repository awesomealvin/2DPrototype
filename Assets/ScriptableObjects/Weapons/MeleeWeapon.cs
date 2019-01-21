using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapons/Melee Weapon")]
public class MeleeWeapon : Weapon
{
    public float damageRadius;

    public override void Use(WeaponController weaponController)
    {
        Vector3 weaponPosition = weaponController.weaponPosition.position;

        float amount = 30.0f;
        float length = 360.0f / amount;

        float current = 0.0f;

        float hyp = damageRadius;
        for (int i = 0; i < amount; ++i)
        {
            float radians = Mathf.Deg2Rad * current;
            float x = Mathf.Cos(radians) * hyp;
            float y = Mathf.Sin(radians) * hyp;
            Vector3 end = new Vector3(x + weaponPosition.x, y + weaponPosition.y, 0.0f);
            Debug.DrawLine(weaponPosition, end, Color.red, 1.0f);

            current += length;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(weaponPosition, damageRadius, layerMasks.layers);
        // Debug.Log("Collider Count = " + colliders.Length);
        foreach (Collider2D c in colliders)
        {
            // Debug.Log("Collider Found");
            Debug.Log(weaponController.transform);
            Debug.Log(c.transform.root);
            // Makes sure the "user" doesn't hit itself lul
            if (weaponController.transform == c.transform.parent)
            {
                continue;
            }

            CircleController circleController = c.gameObject.GetComponentInParent<CircleController>();

            if (circleController != null)
            {
                HealthController healthController = circleController.healthController;
                // Debug.Log("Damage Controller Found");
                Vector2 a = weaponController.transform.position;
                Vector2 b = healthController.transform.position;
                Vector2 direction = (b - a).normalized;
                Vector2 force = direction * this.force;
                healthController.Damage(damage, force, 1.0f, weaponController.circleController.entityType);
            }

            // Destroy(c.gameObject);
        }
    }
}