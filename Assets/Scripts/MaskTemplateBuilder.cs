using UnityEngine;
using UnityEngine.UI;

public class MaskTemplateBuilder : MonoBehaviour
{
    [SerializeField] private Image shapeImage;
    [SerializeField] private Image shapeColorImage;
    [SerializeField] private Image patternImage;
    [SerializeField] private Image patternColorImage;
    [SerializeField] private Image outlineImage;
    [SerializeField] private Image eyeAndMouthImage;

    public void GenerateMask(Mask mask)
    {
        shapeImage.sprite = GameManager.gameManager.masksSprites["shape"][mask.attributes["shape"]];
        shapeColorImage.sprite = GameManager.gameManager.masksColors["shape"][mask.colors["shape"]];
        shapeImage.sprite = GameManager.gameManager.masksSprites["pattern"][mask.attributes["pattern"]];
        shapeColorImage.sprite = GameManager.gameManager.masksColors["pattern"][mask.colors["pattern"]];
        outlineImage.sprite = GameManager.gameManager.masksOutlines[mask.attributes["shape"]];
        eyeAndMouthImage.sprite = GameManager.gameManager.masksSprites["decoration"][mask.attributes["decoration"]];
    }
}
