using TMPro;
using UnityEngine;

public class PlayerNotificationHandler : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip animation;
    
    public static PlayerNotificationHandler playerNotificationHandler;

    private void Awake()
    {
        playerNotificationHandler = this;
    }
    
    public void NotifyGreen(string message)
    {
        obj.SetActive(true);
        notificationText.colorGradient = new VertexGradient(Color.green, Color.green, Color.green, Color.green);
        notificationText.text = message;
        animator.Play(animation.name, 0, 0f);
    }
    
    public void NotifyRed(string message)
    {
        obj.SetActive(true);
        notificationText.colorGradient = new VertexGradient(Color.red, Color.red, Color.red, Color.red);
        notificationText.text = message;
        animator.Play(animation.name, 0, 0f);
    }
}
