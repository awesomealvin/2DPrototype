using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    List<ProjectileObjectPool> projectilePools;

    void Start()
    {
        InitialiseProjectiles();
    }

    private void InitialiseProjectiles()
    {
        for (int i = 0; i < projectilePools.Count; ++i)
        {
            projectilePools[i].Initialise(this.transform);
        }
    }
}
