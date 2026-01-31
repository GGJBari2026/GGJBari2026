using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    public static SlotsManager slotsManager;
    
    public Slot[] slots = { new(), new(), new() };
    
    private void Awake()
    {
        slotsManager = this;
    }

    public int TryAssignSlot(Mask targetMask)
    {
        for (var i = 0; i < slots.Length; i++)
        {
            var slot = slots[i];
            if (slot.state == SlotState.Empty)
            {
                slot.SetOnShape(targetMask);
                return i;
            }
        }

        return -1;
    }
    
}
