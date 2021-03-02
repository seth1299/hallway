using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

// The StartGame() function loads the "Project2" scene, which should be the actual game content.
public void StartGame()
{
    SceneManager.LoadScene("Project2");
}

// The About() function loads the "About" scene, which should contain the instructions for how to play the game.
public void About()
{
    SceneManager.LoadScene("About");
}

// The Lose() function loads the "Lose" scene, which should contain the game over menu for the game.
public void Lose()
{
    SceneManager.LoadScene("Credits");
}

// The MainMenu() function returns the user to the main menu.
public void MainMenu()
{
    SceneManager.LoadScene("MainMenu");
}

public void Pause()
{
    SceneManager.LoadScene("Pause");
}
public void Win()
{
    SceneManager.LoadScene("Win");
}

// This quits the game when the "exit" button is clicked.

public void Exit()
{
    Application.Quit();
}

void Update()
{
    // This code simply closes the application when the "ESC" key is pressed, as required in the "requirements for ALL games" section on Webcourses.
    if (Input.GetKey("escape"))
    {
        Application.Quit();
    }
}

}