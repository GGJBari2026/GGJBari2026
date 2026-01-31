using UnityEngine;
using UnityEngine.UI;

public class MaskTemplateBuilder : MonoBehaviour
{
    [SerializeField] private Image shapeImage;
    [SerializeField] private Image patternImage;
    [SerializeField] private Image outlineImage;
    [SerializeField] private Image eyeAndMouthImage;

    public void GenerateMask(Mask mask)
    {
        shapeImage.sprite = GameManager.gameManager.masksSprites["shape"][mask.attributes["shape"]];
        //patternImage.color = GameManager.gameManager.masksSprites["color"][mask.attributes["color"]];
        patternImage.sprite = GameManager.gameManager.masksSprites["eyes"][mask.attributes["eyes"]];
    }
}
