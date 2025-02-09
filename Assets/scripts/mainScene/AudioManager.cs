using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour { 
    
    public AudioClip PuckCollision;
    public AudioClip Goal;
    public AudioClip LostGame;
    public AudioClip WonGame;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollsion()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void PlayLostGame()
    {
        audioSource.PlayOneShot(LostGame);
    }

    public void PlayWonGame()
    {
        audioSource.PlayOneShot(WonGame);
    }
}
