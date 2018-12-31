using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        float horionztal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Debug.Log("Horizontal: " + horionztal);
        // Debug.Log("Vertical: " + vertical);

        if (horionztal > 0.0f)
        {
            movementController.MoveRight();
            Debug.Log("Move Right Pressed");
        }
        else if (horionztal < 0.0f)
        {
            movementController.MoveLeft();
            Debug.Log("Move Left Pressed");

        }

        if (vertical > 0.0f)
        {
            movementController.MoveUp();
            Debug.Log("Move Up Pressed");

        }
        else if (vertical < 0.0f)
        {
            movementController.MoveDown();
            Debug.Log("Move Down Pressed");

        }
    }
}