using System;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Instance;
    
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField] private AudioClip take;
    [SerializeField] private AudioClip good;
    [SerializeField] private AudioClip bad;
    [SerializeField] private AudioClip away;
    [SerializeField] private AudioClip cant;
    [SerializeField] private AudioClip lose;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayTake()
    {
        audioSource.PlayOneShot(take);
    }
    
    public void PlayGood()
    {
        audioSource.PlayOneShot(good);
    }
    
    public void PlayBad()
    {
        audioSource.PlayOneShot(bad);
    }
    
    public void PlayAway()
    {
        audioSource.PlayOneShot(away);
    }
    
    public void PlayCant()
    {
        audioSource.PlayOneShot(cant);
    }
    
    public void PlayLose()
    {
        audioSource.PlayOneShot(lose);
    }
}
