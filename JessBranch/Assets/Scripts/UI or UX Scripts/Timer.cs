using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Tooltip("The amount of time the player has to complete the game.")]
    public float timeRemaining;
    private bool timerRunning = true;
    [Tooltip("The text object that the remaining time is displayed with.")]
    public TextMeshProUGUI timerText;
    [Tooltip("The text object that losing is displayed with. Currently just for prototyping, this will be replaced with an actual 'game over' canvas in the future.")]
    public TextMeshProUGUI lossText;
    float seconds = 10.0f;
    [Tooltip("The 'gameController' game object, e.g. the empty game object that should be handling basic things like closing via ESC.")]
    public GameObject gameController;
    [Tooltip("The 'musicController' game object, e.g. the empty game object that should be handling music.")]
    public GameObject musicController;
    private bool gameOver = false;
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
            SceneManager.LoadScene("Defeat");
            musicController.GetComponent<MusicController>().playSound(false);
            timerText.text = "Time remaining: 0";
            lossText.text = "You lost, time ran out!";
            alreadyPlayedMusic = true;
        }
    }
}