﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public float delay;
    public int damage;

    public Sprite damageIndicator;
    public Sprite damageChargeDelayIndicator;
    
    public abstract void Use(WeaponController weaponController); // TODO: Add parameter WeaponController


    
}
