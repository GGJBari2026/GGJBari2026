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
        orderWindowHandler.client.SendOrder(slotIndex);
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
