using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;

    public Transform weaponPosition;

    private float currentDelay = -1.0f;

    void Start()
    {

    }

    void Update()
    {
        if (currentDelay > 0.0f)
        {
            currentDelay -= Time.deltaTime;
        }
    }

    public void Use()
    {
        // TODO: Semi-automatic
        if (currentDelay <= 0.0f)
        {
            Debug.Log(transform.rotation.eulerAngles);
            weapon.Use(this);
            currentDelay = weapon.delay;
            ParticleSystemManager.instance.EmitParticles(ParticleSystemManager.ParticleType.MELEE, transform);
        }
    }

    public Vector2 GetDirection()
    {
        return transform.right;
    }
}