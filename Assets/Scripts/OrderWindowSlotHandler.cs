using System;
using UnityEngine;
using UnityEngine.UI;

public class OrderWindowSlotHandler : MonoBehaviour
{
    [SerializeField] private OrderWindowHandler orderWindowHandler;
    [SerializeField] private int slotIndex;
    [SerializeField] private Image disabledImage;
    [SerializeField] private Image currentImage;
    
    public void Send()
    {
        var slot = SlotsManager.slotsManager.slots[slotIndex];
        slot.Clear(orderWindowHandler.client.generatedOrder);
        orderWindowHandler.CloseWindow();
    }

    private void OnEnable()
    {
        CheckDisable();
        //currentImage.sprite = orderWindowHandler.client.generatedOrder.GetSpriteFromOrder();
    }

    private void CheckDisable()
    {
        disabledImage.enabled = SlotsManager.slotsManager.slots[slotIndex].state != SlotState.Complete;
    }
    
}
