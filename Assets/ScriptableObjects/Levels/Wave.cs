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
        List<CircleController> enemiesList = new List<CircleController>();

        for (int i = 0; i < enemyTypes.Count; ++i)
        {
            for (int j = 0; j < enemyTypes[j].amount; ++j)
            {
                CircleController enemy = enemyTypes[j].enemyObjectPool.Obtain();
                enemy.gameObject.SetActive(false);
                enemiesList.Add(enemy);
            }
        }

        ShuffleList(enemiesList);
    }

    private void ShuffleList(List<CircleController> list)
    {
        for (int i = list.Count- 1; i > 0; --i)
        {
            int random = Random.Range(0, i);
            CircleController temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

}