using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public CircleObjectPool fister;
    public CircleObjectPool shooter;
    public ProjectileObjectPool projectile;
    public CircleObjectPool player;

    void Start()
    {
        shooter.Initialise(this.transform);
        fister.Initialise(this.transform);
        projectile.Initialise(this.transform);
        player.Initialise(this.transform);
    }

    public void SpawnPlayer()
    {
        Debug.Log("Spawned Player");
        CircleController playerObj = player.Obtain();
        playerObj.Initialise(new Vector2(0, 0));
    }

    public void KillAll()
    {
        CircleController[] fisterArray = fister.GetAll();
        CircleController[] shooterArray = shooter.GetAll();
        CircleController[] playerArray = player.GetAll();

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