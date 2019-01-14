using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public static ParticleSystemManager instance;

    [SerializeField]
    private List<ParticleSystemController> particleList;

    private Dictionary<ParticleType, ParticleSystemController> particleDictionary;

    public enum ParticleType
    {
        MELEE
    }

    void Awake()
    {
        instance = this;
        particleDictionary = new Dictionary<ParticleType, ParticleSystemController>();
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
        ParticleSystemController controller = particleDictionary[particleType];
        if (controller != null)
        {
            controller.Emit(otherTransform);
        }
    }

    public void EmitParticles(ParticleType particleType, Vector2 position, Vector3 rotation)
    {
        ParticleSystemController controller = particleDictionary[particleType];
        if (controller != null)
        {
            controller.Emit(position, rotation);
        }
    }

}