using UnityEngine;

public class PlayerInteractionsDetector : MonoBehaviour
{
    private Interactable currentInteractable;
    [SerializeField] private GameObject toast;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            var interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                toast.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Do();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = null;
            toast.SetActive(false);
        }
    }
}
