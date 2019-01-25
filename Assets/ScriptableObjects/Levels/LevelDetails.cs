using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels/Level Details")]
public class LevelDetails : ScriptableObject
{
    public int currentLevel;
    public int currentWave;
    public int totalWaves;
    public int levelScore;
    public int enemiesRemaining;

    public void Initialise()
    {
        currentLevel = 0;
        currentWave = 0;
        totalWaves = 0;
        levelScore = 0;
        enemiesRemaining = 0;
    }
}
