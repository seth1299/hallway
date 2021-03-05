using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{

    // "canvas" is the Canvas object that you want to control. In this case, it's the entire "Pause Menu" canvas.
    public Canvas canvas;

    // "isPaused" keeps track of if the game is paused or not. "true" if the game is paused, otherwise it is "false".
    private bool isPaused = false;

    // "about" keeps track of if the player is on the "about" screen or not. "true" if the player is on the pause screen, or "false" otherwise.
    private bool about = false;

    // Start() is called once at the Scene load.
    void Start()
    {
        // This just sets the "Pause" menu to be invisible when the game starts.
        canvas.enabled = false;
    }

    // Update is called once per frame.
    void Update()
    {
        // This sets paused to true if it is currently false or vice versa. It also recognizes if the player is in the about menu and closes that out (only if the
        // game is already paused)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == true)
                isPaused = false;
            else if (isPaused == false)
                isPaused = true;
            //isPaused = !isPaused;
            Debug.Log("Checking if the game is paused from inside of the Pause Menu Controller: " + GetIsPaused());
            if ( about )
                about = false;
        }

        // This makes the pause menu "appear" and "disappear" at the appropriate times (when paused or the about menu is clicked)
        if ( isPaused && !about)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
        if ( about )
        {
            canvas.enabled = false;
        }

        // This sets the time scale to 0 if the game is paused, otherwise sets it to 1. Meaning time doesn't move when paused and it resumes again when unpaused.
        if ( isPaused )
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    // AboutMenu() handles "changing" the "pause" menu to the "about" menu in-game (not in the main menu).
    public void AboutMenu()
    {
        about = true;
    }

    // GetIsPaused() returns true if the game is paused, otherwise it returns false.
    public bool GetIsPaused()
    {
        return isPaused;
    }

    // GetIsInAboutMenu() returns true if the player is in the About, otherwise it returns false.
    public bool GetIsInAboutMenu()
    {
        return about;
    }
}
