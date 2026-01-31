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
}