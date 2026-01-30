using UnityEngine;

public static class MaskGenerator
{
    public static Mask GenerateRandomMask()
    {
        var shape = (MaskShape)Random.Range(0, System.Enum.GetValues(typeof(MaskShape)).Length);
        var color = (MaskColor)Random.Range(0, System.Enum.GetValues(typeof(MaskColor)).Length);
        var eyes = (MaskEyes)Random.Range(0, System.Enum.GetValues(typeof(MaskEyes)).Length);
        var mouth = (MaskMouth)Random.Range(0, System.Enum.GetValues(typeof(MaskMouth)).Length);

        return new Mask
        {
            shape = shape,
            color = color,
            eyes = eyes,
            mouth = mouth
        };
    }
}
