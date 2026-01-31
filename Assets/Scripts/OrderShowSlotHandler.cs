using System;
using UnityEngine;
using UnityEngine.UI;

public class OrderShowSlotHandler : MonoBehaviour
{
    [SerializeField] private int slotIndex;
    [SerializeField] private Image disabledImage;
    [SerializeField] private Image currentImage;
    
    private void OnEnable()
    {
        CheckDisable();
        //currentImage.sprite = MaskSlotsManager.maskSlotsManager.maskSlots[slotIndex];
    }

    private void CheckDisable()
    {
        disabledImage.enabled = SlotsManager.slotsManager.slots[slotIndex].state != SlotState.Complete;
    }
    
}
