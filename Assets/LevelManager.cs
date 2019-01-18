using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public CircleObjectPool fister;
    public CircleObjectPool shooter;
    public ProjectileObjectPool projectile;

    void Start()
    {
        shooter.Initialise(this.transform);
        fister.Initialise(this.transform);
    }
}
