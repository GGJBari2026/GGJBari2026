using System.Collections.Generic;
using UnityEngine;

public static class MaskGenerator
{
    public static Mask GenerateRandomMask()
    {
        var mask = new Mask();
        foreach (var att in GameManager.gameManager.masksSprites)
        {
            mask.attributes.Add(att.Key, Random.Range(0, att.Value.Length));
        }
        
        List<int> pickedColors = new List<int>();
        foreach (var att in GameManager.gameManager.masksColors)
        {
            // make it so colors can't be the same
            int colorIndex;
            do
            {
                colorIndex = Random.Range(0, att.Value.Length);
            } while (pickedColors.Contains(colorIndex) && att.Value.Length > pickedColors.Count);
            pickedColors.Add(colorIndex);
            mask.colors.Add(att.Key, colorIndex);
        }
        
        return mask;
    }
}