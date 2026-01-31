using UnityEngine;

public class Slot
{
    public Mask targetMask;
    public Mask currentMask;
    public SlotState state = SlotState.Empty;

    public void SetOnShape(Mask targetMask)
    {
        this.targetMask = targetMask;
        currentMask = new Mask();
        state = SlotState.OnShape;
    }

    public void Progress(string key, int value)
    {
        if (state == SlotState.Complete) return;
        currentMask.attributes[key] = value;
        state += 1;
    }
    
    public int Clear()
    {
        var errors = 0;
        foreach (var key in targetMask.attributes.Keys)
        {
            if (!currentMask.attributes.ContainsKey(key) || currentMask.attributes[key] != targetMask.attributes[key])
            {
                errors++;
            }
        }
        targetMask = null;
        currentMask = null;
        state = SlotState.Empty;
        
        return errors;
    }
}

public enum SlotState
{
    Empty,
    OnShape,
    OnColor,
    OnEyes,
    OnMouth,
    Complete
}