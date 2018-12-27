using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        float horionztal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool isMoving = false;

        if (horionztal > 0.0f || horionztal < 0.0f)
        {
            isMoving = true;
        }
        
        if (vertical > 0.0f || vertical < 0.0f)
        {
            isMoving = true;
        }
    }
}
