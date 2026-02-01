using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private Animator animator;

    private bool lastWalkedRight;
    
    private void Update()
    {
        if (WindowManager.windowManager.windowOpened || !GameManager.gameManager.gameStarted) return;

        var isWalkingVal = 0;
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position += Vector3.right * (Time.deltaTime * speed);
            lastWalkedRight = true;
            isWalkingVal = 2;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);
            lastWalkedRight = false;
            isWalkingVal = 1;
        }
        
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.position += Vector3.forward * (Time.deltaTime * speed);
            isWalkingVal = lastWalkedRight ? 2 : 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.position += Vector3.back * (Time.deltaTime * speed);
            isWalkingVal = lastWalkedRight ? 2 : 1;
        }
        
        animator.SetInteger("IsWalking", isWalkingVal);
    }
    
}
