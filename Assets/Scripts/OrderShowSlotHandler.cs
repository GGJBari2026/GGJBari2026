using System;
using UnityEngine;
using UnityEngine.UI;

public class OrderShowSlotHandler : MonoBehaviour
{
    [SerializeField] private int slotIndex;
    [SerializeField] private Image disabledImage;
    [SerializeField] private MaskTemplateBuilder currentTemplate;
    
    private void OnEnable()
    {
        CheckDisable();
        currentTemplate.GenerateMask(MaskSlotsManager.maskSlotsManager.maskSlots[slotIndex]);
    }

    private void CheckDisable()
    {
        disabledImage.enabled = false;
    }
    
}
