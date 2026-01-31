using System;
using System.Collections;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private float patienceTime;
    [SerializeField] private bool special;
    [SerializeField] private Mask generatedOrder;
    [SerializeField] private Interactable interactable;

    private int slotNumber = -1;
    
    public event Action OnEnd;
    
    private void Start()
    {
        if (!special) generatedOrder = MaskGenerator.GenerateRandomMask();
        interactable.SetAction(StartOrder);
    }

    public void StartOrder()
    {
        var slot = SlotsManager.slotsManager.TryAssignSlot(generatedOrder);
        if (slot != -1)
        {
            slotNumber = slot;
            interactable.SetAction(SendOrder);
        }
    }
    
    public void SendOrder()
    {
        var slot = SlotsManager.slotsManager.slots[slotNumber];
        if (slot.state != SlotState.Complete)
            return;
        var correct = slot.Clear();
        if (correct)
        {
            // Reward the player
        }
        else
        {
            // Penalize the player
        }
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnEnd?.Invoke();
    }
}
