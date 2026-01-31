using UnityEngine;

public class Slot
{
    public Mask currentMask = new();
    public SlotState state = SlotState.OnShape;

    public void Progress(string key, int value)
    {
        if (state == SlotState.Complete) return;
        currentMask.attributes[key] = value;
        state += 1;
    }
    
    public int Clear(Mask targetMask)
    {
        var errors = 0;
        foreach (var key in targetMask.attributes.Keys)
        {
            if (!currentMask.attributes.ContainsKey(key) || currentMask.attributes[key] != targetMask.attributes[key])
            {
                errors++;
            }
        }
        currentMask = null;
        state = SlotState.OnShape;
        
        return errors;
    }
}

public enum SlotState
{
    OnShape,
    OnColor,
    OnPattern,
    OnMEyesouth,
    Complete
}