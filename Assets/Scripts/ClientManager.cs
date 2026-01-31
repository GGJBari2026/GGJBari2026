using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private float patienceTime;
    [SerializeField] private float patienceHappy;
    [SerializeField] private float patienceIrritated;
    [SerializeField] private bool special;
    [SerializeField] private Mask generatedOrder;
    [SerializeField] private Interactable interactable;
    
    [SerializeField] private Transform patienceBar;
    private float currentTimer;

    private int slotNumber = -1;

    private bool orderStarted;
    
    public event Action OnEnd;
    
    private void Start()
    {
        if (!special) generatedOrder = MaskGenerator.GenerateRandomMask();
        interactable.SetAction(StartOrder);
        currentTimer = patienceTime;
    }

    private void Update()
    {
        if (!orderStarted) return;
        patienceBar.localPosition = new Vector3(currentTimer / patienceTime - 1, 0, 0);
        currentTimer -= Time.deltaTime;
        
        if (currentTimer <= 0)
        {
            GameManager.gameManager.SubtractTime(20);
            Destroy(gameObject);
        }
    }

    public void StartOrder()
    {
        orderStarted = true;
        var slot = SlotsManager.slotsManager.TryAssignSlot(generatedOrder);
        if (slot != -1)
        {
            slotNumber = slot;
            interactable.SetAction(SendOrder);
        }
        
        GameManager.gameManager.ordersTaken += 1;
    }
    
    public void SendOrder()
    {
        var slot = SlotsManager.slotsManager.slots[slotNumber];
        if (slot.state != SlotState.Complete)
            return;
        var errors = slot.Clear();
        if (errors == 0)
        {
            if (currentTimer >= patienceHappy)
            {
                GameManager.gameManager.AddTime(30);
                GameManager.gameManager.ordersHappy++;
            }
            else if (currentTimer >= patienceIrritated)
            {
                GameManager.gameManager.AddTime(10);
                GameManager.gameManager.ordersIrritated++;
            } else 
            {
                GameManager.gameManager.ordersAngry++;
            }
            
            GameManager.gameManager.ordersCorrect += 1;
        }
        else
        {
            GameManager.gameManager.totalErrors += errors;
        }
        
        GameManager.gameManager.ordersCompleted += 1;
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnEnd?.Invoke();
    }
}
