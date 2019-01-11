using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RangeWeapon : Weapon
{
    public float targetRange;

    public GameObject projectile;

    public float spread;

    public float projectileSpeed;

    public override void Use(WeaponController weaponController)
    {
        // Obtain from object pool
        ProjectileController o = ObjectPool.singleton.GetProjectile();
        o.Initialise();

        // Set the position
        o.transform.position = weaponController.weaponPosition.position;

        // Shoot!
        float spreadValue = Random.Range(-spread, spread);

        Vector2 aimDirection = weaponController.GetDirection();
        Vector2 newDirection = Quaternion.AngleAxis(spreadValue, Vector3.forward) * aimDirection.normalized;

        o.rb.AddForce(newDirection * projectileSpeed, ForceMode2D.Impulse);

    }
}