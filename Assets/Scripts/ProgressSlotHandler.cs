using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlotHandler : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private SlotState state;
    [SerializeField] private int slotIndex;

    [SerializeField] private Image disabledImage;
    
    [SerializeField] private ToggleGroup togglesParent;
    [SerializeField] private GameObject togglePrefab;
    
    [SerializeField] private ToggleGroup secondaryParent;

    private int currentValue;
    private int secondaryCurrentValue = -1;
    [SerializeField] private MaskTemplateBuilder currentMask;

    private void Start()
    {
        var sprites = GameManager.gameManager.masksSprites[key];
        for (var i = 0; i < sprites.Length; i++)
        {
            var toggleObj = Instantiate(togglePrefab, togglesParent.transform);
            var toggle = toggleObj.GetComponent<Toggle>();
            var image = toggleObj.GetComponentInChildren<Image>();
            image.sprite = sprites[i];
            toggle.group = togglesParent;
            var index = i; // Capture the current value of i
            toggle.onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    currentValue = index;
                    ApplyTemplateMask();
                }
            });
            
            if (i == 0)
            {
                toggle.isOn = true;
                currentValue = 0;
                ApplyTemplateMask();
            }
        }
        
        if (secondaryParent != null)
        {
            var secondarySprites = GameManager.gameManager.masksColors[key];
            for (var i = 0; i < secondarySprites.Length; i++)
            {
                var toggleObj = Instantiate(togglePrefab, secondaryParent.transform);
                var toggle = toggleObj.GetComponent<Toggle>();
                var image = toggleObj.GetComponentInChildren<Image>();
                image.sprite = secondarySprites[i];
                toggle.group = secondaryParent;
                var index = i; // Capture the current value of i
                toggle.onValueChanged.AddListener(isOn =>
                {
                    if (isOn)
                    {
                        secondaryCurrentValue = index;
                        ApplyTemplateMask();
                    }
                });
                
                if (i == 0)
                {
                    toggle.isOn = true;
                    secondaryCurrentValue = 0;
                    ApplyTemplateMask();
                }
            }
        }
    }

    private void ApplyTemplateMask()
    {
        var maskCopy = SlotsManager.slotsManager.slots[slotIndex].currentMask.DeepCopy();
        maskCopy.attributes[key] = currentValue;
        if (secondaryCurrentValue >= 0) maskCopy.colors[key] = secondaryCurrentValue;
        currentMask.GenerateMask(maskCopy);
    }

    public void Done()
    {
        var slot = SlotsManager.slotsManager.slots[slotIndex];
        slot.Progress(key, currentValue, secondaryCurrentValue);
        CheckDisable();
    }

    private void OnEnable()
    {
        CheckDisable();
    }

    private void CheckDisable()
    {
        disabledImage.enabled = SlotsManager.slotsManager.slots[slotIndex].state != state;
    }
}
