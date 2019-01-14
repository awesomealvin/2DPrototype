using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem pSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EmitLocal(Transform otherTransform)
    {
        transform.SetParent(otherTransform, false);
        pSystem.Play(false);
    }

    public void EmitWorld(Vector2 position, float angle)
    {
        Vector3 originalRotation = transform.eulerAngles;
        transform.position = position;
        transform.eulerAngles = new Vector3(originalRotation.x, originalRotation.y, angle);
        pSystem.Play(false);        
    }
}