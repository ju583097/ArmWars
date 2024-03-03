using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Method to start game
    public void StartGame()
    {
        //Load the game Scene
        SceneManager.LoadScene("LevelSelection");
    }

    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Method to quit game
    public void QuitGame()
    {
        //Quit the application
        Application.Quit();
    }
}
