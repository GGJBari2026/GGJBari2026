using System;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager windowManager;
    [SerializeField] private GameObject orderWindow;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject[] windows;
    
    public bool windowOpened;

    private void Start() => windowManager = this;

    public void OpenWindow(int index)
    {
        for (var i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(i == index);
        }
        
        mainUI.SetActive(false);
        windowOpened = true;
    }

    public void CloseWindow()
    {
        for (var i = 0; i < windows.Length; i++) windows[i].SetActive(false);
        mainUI.SetActive(true);
        windowOpened = false;
    }

    public void OpenOrderWindow(ClientManager client)
    {
        orderWindow.GetComponent<OrderWindowHandler>().client = client;
        orderWindow.SetActive(true);
    }
}
