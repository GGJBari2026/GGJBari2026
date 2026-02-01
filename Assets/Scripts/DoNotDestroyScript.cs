using System;
using UnityEngine;

public class DoNotDestroyScript : MonoBehaviour
{
    public static DoNotDestroyScript instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}