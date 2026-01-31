using UnityEngine;

public class Slot
{
    public Mask currentMask = new();
    public SlotState state = SlotState.OnShape;

    public void Progress(string key, int value, int secondaryValue)
    {
        if (state == SlotState.Complete) return;
        currentMask.attributes[key] = value;
        if (secondaryValue >= 0) currentMask.colors[key] = secondaryValue;
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

        foreach (var color in targetMask.colors.Keys)
        {
            if (!currentMask.colors.ContainsKey(color) || currentMask.colors[color] != targetMask.colors[color])
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
    OnPattern,
    OnDecoration,
    Complete
}