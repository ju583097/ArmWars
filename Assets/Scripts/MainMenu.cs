using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //method to start game
    public void StartGame()
    {
        // Load the game Scene
        SceneManager.LoadScene("GameScreen");
    }

    // Method to quit game
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
