using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void HorizontalMovement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void VerticalMovement(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<Vector2>().y;
    }
}
