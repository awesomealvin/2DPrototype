using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public PooledObject projectilePrefab;
    private Queue<ProjectileController> projectilesPool;

    public static ObjectPool instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        projectilesPool = CreatePool<ProjectileController>(projectilePrefab);
    }

    /// <summary>
    /// Generic function to create an object pool
    /// </summary>
    /// <param name="pooledObject"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private Queue<T> CreatePool<T>(PooledObject pooledObject) where T : RespawnableObject
    {
        Queue<T> pool = new Queue<T>();

        int size = pooledObject.size;
        for (int i = 0; i < size; ++i)
        {
            T objType = InstantiateObject(pool, pooledObject.prefab);

            if (objType != null)
            {
                // Disables object and adds it to the queue
                objType.gameObject.SetActive(false);
                pool.Enqueue(objType);
                // Debug.Log("Added to queue");
            }
            else
            {
                // Destroys object when the component cannot be found... just for extra mesaures
                Destroy(objType.gameObject);
            }
        }

        return pool;
    }

    /// <summary>
    /// Instantiates an object and returns it as the generic type specified
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="prefab"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T InstantiateObject<T>(Queue<T> pool, GameObject prefab) where T : RespawnableObject
    {
        GameObject obj = GameObject.Instantiate(prefab, new Vector3(-20.0f, -20.0f, -20.0f), Quaternion.identity, transform);
        T objType = obj.GetComponent<T>();

        return objType;
    }

    /// <summary>
    /// Generic function to obtain an object from the object pool.
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="prefab"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T GetObject<T>(Queue<T> pool, GameObject prefab) where T : RespawnableObject
    {
        T obj;

        // If the queue is empty, then instantiate a new one. (hopefully this doesn't get called too often)
        if (pool.Count <= 0)
        {
            obj = InstantiateObject(pool, prefab);
        }
        else
        {
            obj = pool.Dequeue();
        }

        obj.gameObject.SetActive(true);

        return obj;
    }

    public ProjectileController GetProjectile()
    {
        return GetObject<ProjectileController>(projectilesPool, projectilePrefab.prefab);
    }

    public void AddProjectileToQueue(ProjectileController projectile)
    {
        projectilesPool.Enqueue(projectile);
    }

}