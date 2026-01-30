using UnityEngine;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private int windowIndex;
    
    public void OpenWindow()
    {
        WindowManager windowManager = FindObjectOfType<WindowManager>();
        if (windowManager != null)
        {
            windowManager.OpenWindow(windowIndex);
        }
    }
    
}
