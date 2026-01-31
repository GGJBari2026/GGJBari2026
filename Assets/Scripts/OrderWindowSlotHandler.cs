using System;
using UnityEngine;
using UnityEngine.UI;

public class OrderWindowSlotHandler : MonoBehaviour
{
    [SerializeField] private OrderWindowHandler orderWindowHandler;
    [SerializeField] private int slotIndex;
    [SerializeField] private Image disabledImage;
    [SerializeField] private MaskTemplateBuilder currentTemplate;
    
    public void Send()
    {
        orderWindowHandler.client.SendOrder(slotIndex);
        orderWindowHandler.CloseWindow();
    }

    private void OnEnable()
    {
        CheckDisable();
        currentTemplate.GenerateMask(SlotsManager.slotsManager.slots[slotIndex].currentMask);
    }

    private void CheckDisable()
    {
        disabledImage.enabled = SlotsManager.slotsManager.slots[slotIndex].state != SlotState.Complete;
    }
    
}
