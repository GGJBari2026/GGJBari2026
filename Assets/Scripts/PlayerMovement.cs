using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private Animator animator;
    
    private void Update()
    {
        if (WindowManager.windowManager.windowOpened || !GameManager.gameManager.gameStarted) return;
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position += Vector3.right * (Time.deltaTime * speed);
            animator.SetBool("isFlipped", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);
            animator.SetBool("isFlipped", true);
        }
        
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.position += Vector3.forward * (Time.deltaTime * speed);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.position += Vector3.back * (Time.deltaTime * speed);
        }
    }
    
}
