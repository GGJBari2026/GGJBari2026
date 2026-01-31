using UnityEngine;
using UnityEngine.UI;

public class MaskTemplateBuilder : MonoBehaviour
{
    [SerializeField] private Sprite noSprite;
    [SerializeField] private Sprite whiteSprite;
    
    [SerializeField] private Image shapeImage;
    [SerializeField] private Image shapeColorImage;
    [SerializeField] private Image patternImage;
    [SerializeField] private Image patternColorImage;
    [SerializeField] private Image outlineImage;
    [SerializeField] private Image eyeAndMouthImage;

    public void GenerateMask(Mask mask)
    {
        shapeImage.sprite = mask.attributes.ContainsKey("shape") ? GameManager.gameManager.masksSprites["shape"][mask.attributes["shape"]] : noSprite;
        shapeColorImage.sprite = mask.colors.ContainsKey("shape") ? GameManager.gameManager.masksColors["shape"][mask.colors["shape"]] : whiteSprite;
        patternImage.sprite = mask.attributes.ContainsKey("pattern") ? GameManager.gameManager.masksSprites["pattern"][mask.attributes["pattern"]] : noSprite;
        patternColorImage.sprite = mask.colors.ContainsKey("pattern") ? GameManager.gameManager.masksColors["pattern"][mask.colors["pattern"]] : whiteSprite;
        outlineImage.sprite = mask.attributes.ContainsKey("shape") ? GameManager.gameManager.masksOutlines[mask.attributes["shape"]] : whiteSprite;
        eyeAndMouthImage.sprite = mask.attributes.ContainsKey("decoration") ? GameManager.gameManager.masksSprites["decoration"][mask.attributes["decoration"]] : noSprite;
    }
}
