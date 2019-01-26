using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public CircleObjectPool playerPool;
    public List<CircleObjectPool> enemyPools;
    [SerializeField] private List<Transform> spawnPoints;

    public ActivePlayer currentActivePlayer;

    [SerializeField] private LevelDetails levelDetails;

    [SerializeField] private Transform circleTransform;
    [SerializeField] private List<Level> levels;

    [SerializeField] private int startingLevel;
    private Level currentLevel;

    private Wave currentWave;

    private Queue<CircleController> enemyQueue;

    private bool on;

    private float currentWaveBreakTime;
    private float currentWaveTime;

    [SerializeField] private GameEvent enemyCountDeductionEvent;
    [SerializeField] private GameEvent waveChangeEvent;

    public enum LevelState
    {
        NONE,
        WAVE_BREAK,
        IN_WAVE
    }

    private LevelState currentLevelState;

    void Start()
    {
        currentLevelState = LevelState.NONE;

        playerPool.Initialise(circleTransform);
        Initialise();
    }

    void Update()
    {
        if (currentLevelState == LevelState.WAVE_BREAK)
        {
            UpdateWaveBreak();
        }
        else if (currentLevelState == LevelState.IN_WAVE)
        {
            UpdateCurrentWave();
        }
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
        levelDetails.currentWave = -1;
        levelDetails.totalWaves = currentLevel.waves.Count;

        // currentWave = currentLevel.waves[levelDetails.currentWave];
        // enemyQueue = currentWave.Initialise();

        levelDetails.enemiesRemaining = 0;
        levelDetails.levelScore = 0;

        waveChangeEvent.Raise();
        enemyCountDeductionEvent.Raise();
    }

    public void DeductEnemyCount()
    {
        levelDetails.enemiesRemaining -= 1;
        enemyCountDeductionEvent.Raise();
    }

    private void SpawnEnemy()
    {
        if (enemyQueue.Count <= 0)
        {
            return;
        }
        CircleController circle = enemyQueue.Dequeue();
        circle.gameObject.SetActive(true);

        int spawnPointIndex = Random.Range(0, spawnPoints.Count - 1);
        circle.Initialise(spawnPoints[spawnPointIndex].position);

        currentWaveTime = currentWave.spawnDelay;
    }

    public void CheckEnemyCount()
    {
        Debug.Log(levelDetails.enemiesRemaining);
        if (levelDetails.enemiesRemaining <= 0)
        {
            StartWaveBreak();
        }
    }

    private void StartWaveBreak()
    {
        currentWaveBreakTime = currentLevel.delayBetweenWaves;
        currentLevelState = LevelState.WAVE_BREAK;
    }

    private void InitialiseEnemyPools()
    {
        for (int i = 0; i < enemyPools.Count; ++i)
        {
            enemyPools[i].Initialise(circleTransform);
        }
    }

    private void UpdateWaveBreak()
    {
        currentWaveBreakTime -= Time.deltaTime;
        if (currentWaveBreakTime <= 0.0f)
        {
            StartNextWave();
        }
    }

    private void UpdateCurrentWave()
    {
        currentWaveTime -= Time.deltaTime;
        if (currentWaveTime <= 0.0f)
        {
            SpawnEnemy();
        }
    }

    private void StartNextWave()
    {
        levelDetails.currentWave += 1;
        Debug.Log("CURRENT WAVE = " + levelDetails.currentWave);

        if (levelDetails.currentWave > currentLevel.waves.Count - 1)
        {
            LevelStop();

        }
        else
        {
            currentWave = currentLevel.waves[levelDetails.currentWave];

            enemyQueue = currentWave.Initialise();
            levelDetails.enemiesRemaining = enemyQueue.Count;
            waveChangeEvent.Raise();
            enemyCountDeductionEvent.Raise();
            currentLevelState = LevelState.IN_WAVE;
        }

    }

    public void LevelStart()
    {
        currentLevelState = LevelState.WAVE_BREAK;
        currentWaveBreakTime = currentLevel.delayBetweenWaves;
    }

    public void LevelStop()
    {
        currentLevelState = LevelState.NONE;
    }

    public void KillAll()
    {
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