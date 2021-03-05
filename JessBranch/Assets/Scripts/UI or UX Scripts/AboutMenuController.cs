﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMenuController : MonoBehaviour
{
    // "pauseMenuCanvas" is the pauseMenuCanvas object that you want to control. In this case, it's the entire "Pause Menu" pauseMenuCanvas since we want to reference 
    // those functions later.
    // "thisSameCanvas" is the same canvas that this script is on.
    public Canvas pauseMenuCanvas;
    public Canvas thisSameCanvas;

    // "PMC" is a PauseMenuController script, referenced from another pauseMenuCanvas object (whatever you passed to the "pauseMenuCanvas" object earlier in this script)
    private PauseMenuController PMC;

    // "isInAboutMenu" tracks if the player is in the "About" menu or not. "true" if the player is in the "About" menu, or "false" otherwise.
    public bool isInAboutMenu = false;

    // Start() is called once at the beginning of the Scene load.
    void Start()
    {
        // "PMC" is set to the PauseMenuController script from the "pauseMenuCanvas" object that was passed to this script earlier.
        PMC = pauseMenuCanvas.GetComponent<PauseMenuController>();

        // This disables the "about" menu at the start of the game so that it doesn't show up on accident.
        thisSameCanvas.enabled = false;
    }

    // Update is called once per frame.
    void Update()
    {
        // "isInAboutMenu" is set to the variable returned by the "GetIsInAboutMenu()" function from the "PauseMenuController" script that "PMC" is referencing. 
        // In short, this is just true if the player is in the "about" menu or false otherwise.
        isInAboutMenu = PMC.GetIsInAboutMenu();
        
        // This makes the About Menu visible if the player is in the about menu, otherwise it makes it invisible.
        if ( isInAboutMenu )
            thisSameCanvas.enabled = true;
        else
            thisSameCanvas.enabled = false;
    }
}
