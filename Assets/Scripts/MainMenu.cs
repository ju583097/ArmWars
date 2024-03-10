using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    
    public void StartGame()
    {
        if(SkinManager.instance != null)
        {
            SkinManager.instance.OnEnable();
        }
        SceneManager.LoadScene("CharacterSelect");
    }

    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


     public void OpenSettingsPanel()
    {
        SettingsManager settingsManager = FindObjectOfType<SettingsManager>();
        if (settingsManager != null)
        {
            settingsManager.ToggleSettingsPanel(true);
        }
    }

    
    public void QuitGame()
    { 
        Application.Quit();
    }
}
