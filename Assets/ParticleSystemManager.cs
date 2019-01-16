using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    private static ParticleSystemManager _instance;
    public static ParticleSystemManager instance
    {
        get
        {
            if (_instance == null)
            {
                // If Particle System Manager is not in the scene, then create it.
                // To prevent depenencies for objects using the particle system.
                GameObject newInstanceGameObject = new GameObject("Particle System Manager");
                newInstanceGameObject.AddComponent<ParticleSystemManager>();
                _instance = newInstanceGameObject.GetComponent<ParticleSystemManager>();
            }

            return _instance;
        }

        private set
        {
            _instance = value;
        }

    }

    [SerializeField]
    private List<ParticleSystemController> particleList;

    private Dictionary<ParticleType.ParticleTypes, ParticleSystemController> particleDictionary;

    // public static ParticleSystemManager GetInstance()
    // {
    //     if (instance == null)
    //     {
    //         // If Particle System Manager is not in the scene, then create it.
    //         // To prevent depenencies for objects using the particle system.
    //         GameObject newInstanceGameObject = new GameObject("Particle System Manager");
    //         newInstanceGameObject.AddComponent<ParticleSystemManager>();
    //         instance = newInstanceGameObject.GetComponent<ParticleSystemManager>();
    //     }
    //     return instance;
    // }

    void Awake()
    {
        _instance = this;
        particleDictionary = new Dictionary<ParticleType.ParticleTypes, ParticleSystemController>();

        if (particleList == null)
        {
            particleList = new List<ParticleSystemController>();
        }
    }

    void Start()
    {
        InitialiseParticleDictionary();
    }

    private void InitialiseParticleDictionary()
    {
        foreach (ParticleSystemController p in particleList)
        {
            // particleDictionary.Add(p.particleType, p);
        }
    }

    public void EmitParticles(ParticleType.ParticleTypes particleType, Transform otherTransform)
    {
        if (DoesKeyExist(particleType))
        {
            ParticleSystemController controller = particleDictionary[particleType];

            controller.Emit(otherTransform);
        }

    }

    public void EmitParticles(ParticleType.ParticleTypes particleType, Vector2 position, Vector3 rotation)
    {
        if (DoesKeyExist(particleType))
        {
            ParticleSystemController controller = particleDictionary[particleType];
            controller.Emit(position, rotation);
        }

    }

    private bool DoesKeyExist(ParticleType.ParticleTypes particleType)
    {
        bool found = false;

        if (particleDictionary.ContainsKey(particleType))
        {
            found = true;
        }

        return found;
    }

}