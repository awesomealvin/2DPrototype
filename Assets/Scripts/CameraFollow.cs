using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Position positionToFollow;

    [SerializeField]
    Position offset;

    [SerializeField]
    float smoothTime = 0.5f;

    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = positionToFollow.position + offset.position;
        desiredPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }

    void LateUpdate()
    {

    }
}