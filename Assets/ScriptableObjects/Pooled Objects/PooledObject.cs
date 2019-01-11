using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PooledObject : ScriptableObject
{
    public GameObject prefab;
    
    [SerializeField]
    private int initialSize;

    public int size
    {
        get {return initialSize;}
        private set{}
    }

}
