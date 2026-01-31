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
    [SerializeField] public Mask generatedOrder;
    [SerializeField] private Interactable interactable;
    
    [SerializeField] private Transform patienceBar;
    private float currentTimer;

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
        var slot = MaskSlotsManager.maskSlotsManager.TryAssignMaskSlot(generatedOrder);
        if (slot != -1)
        {
            interactable.SetAction(OpenOrderWindow);
            GameManager.gameManager.ordersTaken += 1;
        }
    }
    
    public void OpenOrderWindow()
    {
        WindowManager.windowManager.OpenOrderWindow(this);
    }
    
    public void SendOrder(int slotNumber)
    {
        var slot = SlotsManager.slotsManager.slots[slotNumber];
        if (slot.state != SlotState.Complete)
            return;
        var errors = slot.Clear(generatedOrder);
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
        
        OnEnd?.Invoke();
        Destroy(gameObject);
    }
}
