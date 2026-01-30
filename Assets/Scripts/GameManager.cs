using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeInSeconds = 12 * 60;
    private float currentTimer;
    private bool gameStarted;
    
    private Image timerImage;
    
    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        while (!gameStarted) return;
        currentTimer -= Time.deltaTime;
        
        timerImage.fillAmount = currentTimer / timeInSeconds;
        
        if (currentTimer <= 0)
        {
            gameStarted = false;
            Debug.Log("Time's up! Game Over.");
        }
    }
    
    private void StartGame()
    {
        gameStarted = true;
        currentTimer = timeInSeconds;
    }
}
