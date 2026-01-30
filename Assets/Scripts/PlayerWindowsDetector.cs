using UnityEngine;

public class PlayerWindowsDetector : MonoBehaviour
{
    private WindowOpener currentWindowOpener;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Window"))
        {
            WindowOpener windowOpener = other.GetComponent<WindowOpener>();
            if (windowOpener != null)
            {
                currentWindowOpener = windowOpener;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentWindowOpener != null)
        {
            currentWindowOpener.OpenWindow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Window"))
        {
            currentWindowOpener = null;
        }
    }
}
