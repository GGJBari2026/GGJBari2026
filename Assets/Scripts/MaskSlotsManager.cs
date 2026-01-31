using UnityEngine;

public class MaskSlotsManager : MonoBehaviour
{
    public static MaskSlotsManager maskSlotsManager;
    
    public Mask[] maskSlots = { null, null, null };
    
    private void Awake()
    {
        maskSlotsManager = this;
    }

    public int TryAssignMaskSlot(Mask targetMask)
    {
        for (var i = 0; i < maskSlots.Length; i++)
        {
            if (maskSlots[i].attributes.Count == 0)
            {
                maskSlots[i] = targetMask;
                return i;
            }
        }

        return -1;
    }
    
    public void ClearMaskSlot(int index)
    {
        if (index < 0 || index >= maskSlots.Length) return;
        maskSlots[index].attributes.Clear();
    }
}
