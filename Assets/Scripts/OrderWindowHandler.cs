using UnityEngine;

public class OrderWindowHandler : MonoBehaviour
{
    [SerializeField] public ClientManager client;
    
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
