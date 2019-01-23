#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolBase<T> : ScriptableObject where T : MonoBehaviour 
{
    protected Queue<T> pool = new Queue<T>();

    public GameObject prefab;

    [SerializeField]
    private int size;

    public int initialSize
    {
        private set{}
        get
        {
            return size;
        }
    }

    public void Add(T obj)
    {  
        pool.Enqueue(obj);
    }

    public T[] GetAll()
    {
        return pool.ToArray();
    }

    public T Obtain()
    {
        T obj;

        if (pool.Count <= 0)
        {
            obj = InstantiateObject();
        }
        else
        {
            obj = pool.Dequeue();
        }

        obj.gameObject.SetActive(true);

        return obj;
    }

    /// <summary>
    /// Instantiates an object and returns it as the generic type specified
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="prefab"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T InstantiateObject(Transform parent)
    {
        GameObject obj = GameObject.Instantiate(prefab, new Vector3(-20.0f, -20.0f, -20.0f), Quaternion.identity, parent);
        T objType = obj.GetComponent<T>();

        return objType;
    }

    private T InstantiateObject()
    {
        GameObject obj = GameObject.Instantiate(prefab, new Vector3(-20.0f, -20.0f, -20.0f), Quaternion.identity);
        T objType = obj.GetComponent<T>();

        return objType;
    }

    public void Initialise(Transform parent)
    {
        for (int i = 0; i < initialSize; ++i)
        {
            T objType = InstantiateObject(parent);
            if (objType != null)
            {
                objType.gameObject.SetActive(false);
                Add(objType);
            }
            else
            {
                Destroy(objType.gameObject);
            }

        }
    }




}
