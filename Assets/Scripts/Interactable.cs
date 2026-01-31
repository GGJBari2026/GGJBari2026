using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Action action;

    public void SetAction(Action action)
    {
        this.action = action;
    }
    
    public void Do()
    {
        action?.Invoke();
    }
}
