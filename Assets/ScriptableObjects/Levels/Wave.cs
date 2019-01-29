using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    // [Header("Enemy Type")]
    [System.Serializable]
    public class WaveData
    {
        public CircleObjectPool enemyObjectPool;
        public int amount;
    }

    public List<WaveData> enemyTypes;
    [Space(15)]

    public float spawnDelay;

    public Queue<CircleController> Initialise()
    {
        List<CircleController> enemiesList = new List<CircleController>();

        for (int i = 0; i < enemyTypes.Count; ++i)
        {
            for (int j = 0; j < enemyTypes[i].amount; ++j)
            {
                CircleController enemy = enemyTypes[i].enemyObjectPool.Obtain();
                enemy.gameObject.SetActive(false);
                enemiesList.Add(enemy);
            }
        }

        ShuffleList(enemiesList);

        Queue<CircleController> enemyQueue = new Queue<CircleController>();
        for (int i = 0; i < enemiesList.Count; ++i)
        {
            enemyQueue.Enqueue(enemiesList[i]);
        }

        return enemyQueue;
    }

    private void ShuffleList(List<CircleController> list)
    {
        for (int i = list.Count - 1; i > 0; --i)
        {
            int random = Random.Range(0, i);
            CircleController temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

}