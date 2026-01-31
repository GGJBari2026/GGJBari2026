using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;


[Serializable]
public class Mask
{
    [SerializedDictionary("Attribute", "Index")]
    public SerializedDictionary<string, int> attributes = new();

    public static bool operator ==(Mask a, Mask b)
    {
        if (a.attributes.Count != b.attributes.Count) return false;

        foreach (var key in a.attributes.Keys)
        {
            if (!b.attributes.ContainsKey(key) || a.attributes[key] != b.attributes[key])
                return false;
        }

        return true;
    }

    public static bool operator !=(Mask a, Mask b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Mask otherMask)
        {
            return this == otherMask;
        }

        return false;
    }
}