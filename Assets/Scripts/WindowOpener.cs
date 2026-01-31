using System;
using UnityEngine;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private int windowIndex;

    private void Start()
    {
        gameObject.GetComponent<Interactable>().SetAction(OpenWindow);
    }

    public void OpenWindow()
    {
        WindowManager.windowManager.OpenWindow(windowIndex);
    }
    
}
