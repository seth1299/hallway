using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10.0f;
    private bool timerRunning = true;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lossText;
    float seconds = 10.0f;
    public GameObject gameController;
    public GameObject musicController;
    bool gameOver = false;
    private bool victory;
    private bool alreadyPlayedMusic = false;

    void Start()
    {
        lossText.text = "";
    }

    void Update()
    {
        gameOver = gameController.GetComponent<GameController>().getGameOver();
        if (timeRemaining > 0 && gameOver == false)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            victory = false;
            timerRunning = false;
        }
        updateTimerText();
    }

    public bool getTimer()
    {
        return !timerRunning;
    }

    public void updateTimerText()
    {
        seconds = Mathf.FloorToInt(timeRemaining);
        if (seconds > 0)
        {
            timerText.text = "Time remaining: " + string.Format("{0}", seconds);
        }
        else if (seconds <= 0 && alreadyPlayedMusic == false)
        {
            musicController.GetComponent<MusicController>().playSound(false);
            timerText.text = "Time remaining: 0";
            lossText.text = "You lost, time ran out!";
            alreadyPlayedMusic = true;
        }
    }
}