﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    [SerializeField]
    AbilityController abilityController;

    [SerializeField]
    Position mousePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        HandleMousePosition();
        HandleAbility();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void HandleMousePosition()
    {
        if (mousePosition == null || abilityController == null)
        {
            return;
        }
        mousePosition.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        abilityController.lookDirection = mousePosition.position;
    }

    void HandleAbility()
    {
        if (abilityController == null)
        {
            return;
        }

        if (Input.GetAxisRaw("Jump") > 0.0f)
        {
            abilityController.UseAbility();
        }
    }


    private void HandleMovementInput()
    {
        if (movementController == null)
        {
            return;
        }
        float horionztal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Debug.Log("Horizontal: " + horionztal);
        // Debug.Log("Vertical: " + vertical);

        if (horionztal > 0.0f)
        {
            movementController.MoveRight();
            // Debug.Log("Move Right Pressed");
        }
        else if (horionztal < 0.0f)
        {
            movementController.MoveLeft();
            // Debug.Log("Move Left Pressed");

        }

        if (vertical > 0.0f)
        {
            movementController.MoveUp();
            // Debug.Log("Move Up Pressed");

        }
        else if (vertical < 0.0f)
        {
            movementController.MoveDown();
            // Debug.Log("Move Down Pressed");

        }
    }
}