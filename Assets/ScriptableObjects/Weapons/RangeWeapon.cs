using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RangeWeapon : Weapon
{
    // public GameObject projectile;

    public float spread;

    public float projectileSpeed;

    public float projectileDuration;


    public override void Use(WeaponController weaponController)
    {
        // Obtain from object pool
        ProjectileController o = ObjectPool.instance.GetProjectile();
        o.Initialise(damage, projectileDuration, force, weaponController.transform.parent);

        // Set the position
        o.transform.position = weaponController.weaponPosition.position;

        // Shoot!
        // Calculate spread
        float spreadValue = Random.Range(-spread, spread);
        // Obtain weapon aim directio
        Vector2 aimDirection = weaponController.GetDirection();
        // Get the rotational offset using the spread value
        Quaternion angleOffset = Quaternion.AngleAxis(spreadValue, Vector3.forward);
        // Apply the angle offset to the aim direction
        Vector2 direction = angleOffset * aimDirection.normalized;

        // Add force to the projectile
        o.rb.AddForce(direction * projectileSpeed, ForceMode2D.Impulse);

    }
}