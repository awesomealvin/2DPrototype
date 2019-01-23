﻿#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem pSystem;

    // public ParticleType.ParticleTypes particleType;

    // Won't need this unless using the optimization (see trello board)
    public void Emit(Transform otherTransform)
    {
        transform.SetParent(otherTransform, false);
        
        // ParticleSystem.EmitParams emitOverrideParams = new ParticleSystem.EmitParams();
        // emitOverrideParams.applyShapeToPosition = true;
        // pSystem.Emit(emitOverrideParams, count);
        // Debug.Log(particleType + "HEllo?");
        pSystem.Play();
    }

    // Won't need this unless using the optimization (see trello board)
    public void Emit(Vector2 position, Vector3 rotation)
    {
        transform.position = position;
        transform.eulerAngles = rotation;

        // ParticleSystem.EmitParams emitOverrideParams = new ParticleSystem.EmitParams();
        // emitOverrideParams.applyShapeToPosition = true;
        // pSystem.Emit(emitOverrideParams, count);
        pSystem.Play();
    }

    public void Play()
    {
        pSystem.Play();
    }

    public void Stop()
    {
        pSystem.Stop(false, ParticleSystemStopBehavior.StopEmitting);
    }

    public void EnableEmission()
    {
        // pSystem.emission.
    }


}