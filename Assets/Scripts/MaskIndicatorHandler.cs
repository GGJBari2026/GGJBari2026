using System;
using UnityEngine;
using UnityEngine.UI;

public class MaskIndicatorHandler : MonoBehaviour
{
    [SerializeField] private Image[] indicatorImages;
    [SerializeField] private Sprite filledSprite;
    [SerializeField] private Sprite unFilledSprite;

    private void Update()
    {
        for (var i = 0; i < indicatorImages.Length; i++)
        {
            if (SlotsManager.slotsManager.slots[i].state == SlotState.Complete)
            {
                indicatorImages[i].sprite = filledSprite;
            }
            else
            {
                indicatorImages[i].sprite = unFilledSprite;
            }
        }
    }
}
