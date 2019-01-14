using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem pSystem;

    public ParticleSystemManager.ParticleType particleType;

    public void Emit(Transform otherTransform)
    {
        transform.SetParent(otherTransform, false);
        
        // ParticleSystem.EmitParams emitOverrideParams = new ParticleSystem.EmitParams();
        // emitOverrideParams.applyShapeToPosition = true;
        // pSystem.Emit(emitOverrideParams, count);
        pSystem.Play();
    }

    public void Emit(Vector2 position, Vector3 rotation)
    {
        transform.position = position;
        transform.eulerAngles = rotation;

        // ParticleSystem.EmitParams emitOverrideParams = new ParticleSystem.EmitParams();
        // emitOverrideParams.applyShapeToPosition = true;
        // pSystem.Emit(emitOverrideParams, count);
        pSystem.Play();
    }


}