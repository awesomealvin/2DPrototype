using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public CircleObjectPool playerPool;
    public List<CircleObjectPool> enemyPools;

    public ActivePlayer currentActivePlayer;

    [SerializeField] private LevelDetails levelDetails;

    [SerializeField] private Transform circleTransform;
    [SerializeField] private List<Level> levels;

    [SerializeField] private int startingLevel;
    private Level currentLevel;

    private Wave currentWave;

    private Queue<CircleController> enemyQueue;

    private bool on;

    private float currentTime;    

    void Start()
    {
        playerPool.Initialise(circleTransform);
        Initialise();
    }

    public void SpawnPlayer()
    {
        Debug.Log("Spawned Player");
        CircleController playerObj = playerPool.Obtain();
        currentActivePlayer.currentPlayer = playerObj;
        playerObj.Initialise(new Vector2(0, 0));
    }

    private void Initialise()
    {
        InitialiseEnemyPools();

        levelDetails.Initialise();

        currentLevel = levels[startingLevel];
        levelDetails.currentLevel = startingLevel;
        levelDetails.currentWave = 0;
        levelDetails.totalWaves = currentLevel.waves.Count;

        currentWave = currentLevel.waves[levelDetails.currentWave];
        enemyQueue = currentWave.Initialise();

        levelDetails.enemiesRemaining = enemyQueue.Count;
        levelDetails.levelScore = 0;

    }

    private void SpawnEnemy()
    {
        CircleController circle = enemyQueue.Dequeue();
        circle.gameObject.SetActive(true);
        
    }

    private void InitialiseEnemyPools()
    {
        for (int i = 0; i < enemyPools.Count; ++i)
        {
            enemyPools[i].Initialise(circleTransform);
        }
    }

    public void LevelStart()
    {
        on = true;
    }

    public void LevelStop()
    {
        on = false;
    }

    public void KillAll()
    {
        // CircleController[] fisterArray = fisterPool.GetAll();
        // CircleController[] shooterArray = shooterPool.GetAll();
        // CircleController[] playerArray = playerPool.GetAll();

        // CircleController[][] circles = { fisterArray, shooterArray, playerArray };

        // foreach (CircleController[] c in circles)
        // {
        //     foreach (CircleController cObj in c)
        //     {
        //         cObj.healthController.Suicide();
        //     }
        // }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Circle"))
        {
            CircleController c = go.GetComponent<CircleController>();
            if (c != null)
            {
                if (c.entityType.type != EntityType.Type.PLAYER)
                {
                    c.healthController.Suicide();

                }

            }
        }

    }
}