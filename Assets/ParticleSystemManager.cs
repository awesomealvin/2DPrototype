using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    private static ParticleSystemManager instance;

    [SerializeField]
    private List<ParticleSystemController> particleList;

    private Dictionary<ParticleType, ParticleSystemController> particleDictionary;

    public enum ParticleType
    {
        MELEE
    }

    public static ParticleSystemManager GetInstance()
    {
        if (instance == null)
        {
            // If Particle System Manager is not in the scene, then create it.
            // To prevent depenencies for objects using the particle system.
            GameObject newInstanceGameObject = new GameObject("Particle System Manager");
            newInstanceGameObject.AddComponent<ParticleSystemManager>();
            instance = newInstanceGameObject.GetComponent<ParticleSystemManager>();
        }
        return instance;
    }

    void Awake()
    {
        instance = this;
        particleDictionary = new Dictionary<ParticleType, ParticleSystemController>();

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
            particleDictionary.Add(p.particleType, p);
        }
    }

    public void EmitParticles(ParticleType particleType, Transform otherTransform)
    {
        if (DoesKeyExist(particleType))
        {
            ParticleSystemController controller = particleDictionary[particleType];

            controller.Emit(otherTransform);
        }

    }

    public void EmitParticles(ParticleType particleType, Vector2 position, Vector3 rotation)
    {
        if (DoesKeyExist(particleType))
        {
            ParticleSystemController controller = particleDictionary[particleType];
            controller.Emit(position, rotation);
        }

    }

    private bool DoesKeyExist(ParticleType particleType)
    {
        bool found = false;
        
        if (particleDictionary.ContainsKey(particleType))
        {
            found = true;
        }

        return found;
    }

}