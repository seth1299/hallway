using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource lossMusic;
    public AudioSource victoryMusic;

    void Start()
    {
        backgroundMusic.Play();
    }

    public void playSound(bool victory)
    {
        backgroundMusic.Stop();
        if (victory == true)
        {
            victoryMusic.Play();
        }
        else
        {
            Debug.Log("Playing loss music...");
            lossMusic.Play();
        }
    }

}