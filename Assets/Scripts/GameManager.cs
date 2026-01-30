using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Mask currentMask;
    private Mask targetMask;

    private int success;
    private int failures;
    
    private void Start()
    {
        UpdateTargetMask();
    }

    private void UpdateTargetMask()
    {
        targetMask = MaskGenerator.GenerateRandomMask();
    }
    
    public void SetCurrentMaskShape(MaskShape shape)
    {
        currentMask.shape = shape;
    }
    
    public void SetCurrentMaskColor(MaskColor color)
    {
        currentMask.color = color;
    }
    
    public void SetCurrentMaskEyes(MaskEyes eyes)
    {
        currentMask.eyes = eyes;
    }
    
    public void SetCurrentMaskMouth(MaskMouth mouth)
    {
        currentMask.mouth = mouth;
    }
    
    public bool CheckMask()
    {
        return currentMask == targetMask;
    }
}
