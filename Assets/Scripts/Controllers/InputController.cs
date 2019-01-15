using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    RotationController rotationController;

    [SerializeField]
    MovementController movementController;

    [SerializeField]
    AbilityController abilityController;

    [SerializeField]
    Position mousePosition;

    [SerializeField]
    WeaponController weaponController;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        HandleMousePosition();
        HandleAbility();
        HandleWeapon();
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (rotationController == null)
        {
            return;
        }
        rotationController.positionToLookAt = mousePosition.position;

    }

    private void HandleWeapon()
    {
        if (weaponController == null)
        {
            return;
        }

        if (Input.GetAxisRaw("Fire1") > 0.0f)
        {
            weaponController.Use();
            // Debug.Log("Input Fire1");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void HandleMousePosition()
    {
        if (mousePosition == null)
        {
            return;
        }
        mousePosition.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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