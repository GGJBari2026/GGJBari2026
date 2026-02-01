using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;

    private bool lastWalkedRight;
    
    private void Update()
    {
        if (WindowManager.windowManager.windowOpened || !GameManager.gameManager.gameStarted) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        int isWalkingVal = 0;

        if (horizontal > 0)
        {
            lastWalkedRight = true;
            isWalkingVal = 1;
        }
        else if (horizontal < 0)
        {
            lastWalkedRight = false;
            isWalkingVal = 2;
        }
        else if (vertical != 0)
        {
            isWalkingVal = lastWalkedRight ? 1 : 2;
        }

        animator.SetInteger("IsWalking", isWalkingVal);
    }
    
}
