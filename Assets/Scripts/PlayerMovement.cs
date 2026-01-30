using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private void Update()
    {
        if (WindowManager.windowManager.windowOpened) return;
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
        
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector3.back * (Time.deltaTime * speed));
        }
    }
    
}
