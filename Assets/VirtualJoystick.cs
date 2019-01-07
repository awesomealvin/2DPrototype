using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private bool touching;
    private Vector2 direction;

    private RectTransform rectTransform;

    [SerializeField]
    private RectTransform parent;

    [SerializeField]
    private MovementController movementController;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        Vector2 imagePosition = Vector2.zero;

        // Converts the position of both points to be in the same area
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            rectTransform.position,
            eventData.pressEventCamera,
            out imagePosition
        );

        direction = (position - imagePosition).normalized;
        // Debug.Log("Image Position: " + imagePosition);
        // Debug.Log("Event Data Position: " + position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touching = true;
        OnDrag(eventData);
        Debug.Log("Joystick Touched");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touching = false;
        direction = Vector2.zero;
        Debug.Log("Joystick Released");
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        if (movementController == null)
        {
            return;
        }
        movementController.Move(direction);

    }

}