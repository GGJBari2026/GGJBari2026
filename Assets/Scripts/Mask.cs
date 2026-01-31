using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;


[Serializable]
public class Mask
{
    [SerializedDictionary("Attribute", "Index")]
    public SerializedDictionary<string, int> attributes = new();
    public SerializedDictionary<string, int> colors = new();
    
    public Mask DeepCopy()
    {
        var newMask = new Mask();
        foreach (var kvp in attributes)
        {
            newMask.attributes.Add(kvp.Key, kvp.Value);
        }
        foreach (var kvp in colors)
        {
            newMask.colors.Add(kvp.Key, kvp.Value);
        }
        return newMask;
    }
}