using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool on = false;

    private float nextSpawnTime;
    public float minSpawnDelay = 0.8f;
    public float maxSpawnDelay = 1.2f;

    public CircleObjectPool fister;

    public CircleObjectPool shooter;
    float shooterSpawnChance = 0.2f;
    

    public List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        RandomiseSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawn();
    }

    private void UpdateSpawn()
    {
        if (!on)
        {
            return;
        }

        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0.0f)
        {
            SpawnEnemy();
            RandomiseSpawnTime();
        }
    }

    private void SpawnEnemy()
    {
        float chance = Random.Range(0.0f, 1.0f);
        CircleController spawn;
        if (chance <= shooterSpawnChance)
        {
            spawn = shooter.Obtain();
        }
        else
        {
            spawn = fister.Obtain();
        }

        int index = Random.Range(0, spawnPoints.Count - 1);
        spawn.Initialise(spawnPoints[index].position);
    }

    private void RandomiseSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    public void StartSpawning()
    {
        on = true;
    }

    public void StopSpawning()
    {
        on = false;
    }

}
