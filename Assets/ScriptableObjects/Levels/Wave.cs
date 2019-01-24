using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [System.Serializable]
    public class WaveData
    {
        public CircleObjectPool enemyObjectPool;
        public int amount;
    }

    public List<WaveData> enemyTypes;
    
    public float spawnDelay;

    private Queue<CircleController> enemyQueue;

    public void Initialise()
    {
        int size = 0;
        for (int i = 0; i < enemyTypes.Count; ++i)
        {
            
        }
    }

}