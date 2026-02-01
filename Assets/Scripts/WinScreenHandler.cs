using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Valutation
{
    SUPERBO,
    DISCRETO,
    MEDIOCRE,
    PESSIMO
}

public class WinScreenHandler : MonoBehaviour
{
    public static WinScreenHandler instance;
    
    [SerializeField] private TextMeshProUGUI totalServed;
    [SerializeField] private TextMeshProUGUI totalErrors;
    [SerializeField] private TextMeshProUGUI matchDuration;
    [SerializeField] private TextMeshProUGUI averagePatienceTime;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI valutationText;

    private Valutation valutation;
    private float score;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);

        totalServed.text = GameManager.gameManager.ordersCompleted.ToString();
        totalErrors.text = GameManager.gameManager.totalErrors.ToString();
        matchDuration.text = (int)GameManager.gameManager.totalTime + " secondi";
        averagePatienceTime.text =
            ((GameManager.gameManager.ordersIrritated * 0.5f + GameManager.gameManager.ordersAngry * 1.0f) /
             Mathf.Max(1, GameManager.gameManager.ordersTaken)).ToString("F2");
        
        score = (GameManager.gameManager.ordersHappy * 1.0f - GameManager.gameManager.totalErrors * 0.5f) /
                Mathf.Max(1, GameManager.gameManager.ordersCompleted);
        valutation = score >= 0.5f ? Valutation.SUPERBO :
                    score >= 0.2f ? Valutation.DISCRETO :
                    score >= 0.05f ? Valutation.MEDIOCRE :
                    Valutation.PESSIMO;
        
        scoreText.text = (score * 10).ToString("F2");
        
        valutationText.text = valutation switch
        {
            Valutation.SUPERBO => "Superbo",
            Valutation.DISCRETO => "Discreto",
            Valutation.MEDIOCRE => "Mediocre",
            Valutation.PESSIMO => "Pessimo"
        };
        
        switch (valutation)
        {
            case Valutation.SUPERBO:
                valutationText.color = Color.forestGreen;
                break;
            case Valutation.DISCRETO:
                valutationText.color = Color.orange;
                break;
            case Valutation.MEDIOCRE:
                valutationText.color = Color.darkOrange;
                break;
            case Valutation.PESSIMO:
                valutationText.color = Color.red;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}