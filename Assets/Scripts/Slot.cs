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
    
    public bool Clear()
    {
        var match = currentMask == targetMask;
        targetMask = null;
        currentMask = null;
        state = SlotState.Empty;
        
        return match;
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