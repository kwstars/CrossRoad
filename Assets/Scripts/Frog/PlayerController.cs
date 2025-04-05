using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpDistance;
    private float moveDistance;
    private Vector2 targetPosition;
    private bool buttonHeld;
    private bool isJumping = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (targetPosition.y - transform.position.y < 0.1f)
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        rb.position = Vector2.Lerp(transform.position, targetPosition, 0.134f);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)
        {
            moveDistance = jumpDistance;
            targetPosition = new Vector2(transform.position.x, transform.position.y + moveDistance);
            isJumping = true;
        }

    }

    public void LongJump(InputAction.CallbackContext context)
    {
        if (context.performed && isJumping)
        {
            moveDistance = jumpDistance * 2;
            buttonHeld = true;
        }

        if (context.canceled && buttonHeld)
        {
            // Debug.Log("LongJump " + moveDistance);
            buttonHeld = false;
            targetPosition = new Vector2(transform.position.x, transform.position.y + moveDistance);
            isJumping = true;
        }
    }

    public void GetTouchPosition(InputAction.CallbackContext context)
    {

    }
}
