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

    private int currentValue;
    [SerializeField] private Image currentImage;

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
                    currentImage.sprite = image.sprite;
                }
            });
            
            if (i == 0)
            {
                toggle.isOn = true;
                currentValue = 0;
                currentImage.sprite = image.sprite;
            }
        }
    }

    public void Done()
    {
        var slot = SlotsManager.slotsManager.slots[slotIndex];
        slot.Progress(key, currentValue);
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
