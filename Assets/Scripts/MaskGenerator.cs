using UnityEngine;

public static class MaskGenerator
{
    public static Mask GenerateRandomMask()
    {
        var mask = new Mask();
        foreach (var att in GameManager.gameManager.masksSprites)
        {
            //mask.attributes.Add(att.Key, Random.Range(0, att.Value.Length));
        }

        return mask;
    }
}