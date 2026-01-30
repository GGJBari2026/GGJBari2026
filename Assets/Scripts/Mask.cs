using UnityEngine;

public class Mask
{
    public MaskShape shape;
    public MaskColor color;
    public MaskEyes eyes;
    public MaskMouth mouth;
    
    public static bool operator ==(Mask a, Mask b)
    {
        return a.shape == b.shape &&
               a.color == b.color &&
               a.eyes == b.eyes &&
               a.mouth == b.mouth;
    }

    public static bool operator !=(Mask a, Mask b)
    {
        return !(a == b);
    }
}

public enum MaskShape
{
    Circle,
    Square,
    Triangle
}

public enum MaskColor
{
    Red,
    Green,
    Blue
}

public enum MaskEyes
{
    Open,
    Closed,
    Winking
}

public enum MaskMouth
{
    Smile,
    Frown,
    Neutral
}