using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeInSeconds;
    public static GameManager gameManager;
    private float currentTimer;
    public bool gameStarted;
    
    [SerializeField] private Image timerImage;
    
    [SerializedDictionary("Attribute", "Sprites")]
    public AYellowpaper.SerializedCollections.SerializedDictionary<string, Sprite[]> masksSprites;
    
    [SerializedDictionary("Attribute", "Colors")]
    public AYellowpaper.SerializedCollections.SerializedDictionary<string, Sprite[]> masksColors;

    public int ordersTaken;
    public int ordersCompleted;
    
    public int ordersHappy;
    public int ordersIrritated;
    public int ordersAngry;
    
    public int ordersCorrect;
    public int totalErrors;

    private void Awake()
    {
        gameManager = this;
    }

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
    
    public void AddTime(float seconds)
    {
        currentTimer += seconds;
    }
    
    public void SubtractTime(float seconds)
    {
        currentTimer -= seconds;
    }
}
