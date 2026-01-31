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
        valutation = score >= 0.7f ? Valutation.SUPERBO :
                    score >= 0.4f ? Valutation.DISCRETO :
                    score >= 0.1f ? Valutation.MEDIOCRE :
                    Valutation.PESSIMO;
        
        scoreText.text = score.ToString("F2");
        valutationText.text = valutation.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}