using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public CircleObjectPool fisterPool;
    public CircleObjectPool shooterPool;
    public ProjectileObjectPool projectilePool;
    public CircleObjectPool playerPool;

    void Start()
    {
        shooterPool.Initialise(this.transform);
        fisterPool.Initialise(this.transform);
        projectilePool.Initialise(this.transform);
        playerPool.Initialise(this.transform);
    }

    public void SpawnPlayer()
    {
        Debug.Log("Spawned Player");
        CircleController playerObj = playerPool.Obtain();
        playerObj.Initialise(new Vector2(0, 0));
    }

    public void KillAll()
    {
        CircleController[] fisterArray = fisterPool.GetAll();
        CircleController[] shooterArray = shooterPool.GetAll();
        CircleController[] playerArray = playerPool.GetAll();

        CircleController[][] circles = { fisterArray, shooterArray, playerArray };

        foreach (CircleController[] c in circles)
        {
            foreach (CircleController cObj in c)
            {
                cObj.healthController.Suicide();
            }
        }

    }
}