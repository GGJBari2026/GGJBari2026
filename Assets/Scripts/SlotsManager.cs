using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    public static SlotsManager slotsManager;
    
    public Slot[] slots = { new(), new(), new() };
    
    private void Awake()
    {
        slotsManager = this;
    }
}
