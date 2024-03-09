using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    
    public GameObject settingsPanel;

    public GameObject howToPlayPanel;

    
    public GameObject pauseMenuPanel;

    public GameObject singlePlayerControlsPanel;
    public GameObject multiPlayerControlsPanel;
    
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;

    

    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if(settingsPanel == null)
        {
            //scream, cry, throw up, etc.
        }
    }

    
    public void ToggleSettingsPanel(bool state)
    {
        settingsPanel.SetActive(state);
    }

    
   public void ShowHowToPlayPage()
   {
      if (howToPlayPanel != null)
      {
         howToPlayPanel.SetActive(true);
         ToggleSettingsPanel(false);
      }
   }

  
   public void ReturnFromHowToPlay()
   {
      if (settingsPanel != null && howToPlayPanel != null)
      {
         howToPlayPanel.SetActive(false);
         ToggleSettingsPanel(true);
      }
   }

   

    
    public void ShowSinglePlayerControlsPage()
    {
        singlePlayerControlsPanel.SetActive(true); 
        ToggleSettingsPanel(false);
    }

    public void ReturnFromSinglePlayerControlsPanel()
    {
        singlePlayerControlsPanel.SetActive(false);
        ToggleSettingsPanel(true);
    }

    
     public void ShowVersusPlayerControlsPage()
     {
        multiPlayerControlsPanel.SetActive(true);
        ToggleSettingsPanel(false);
     }
     public void ReturnFromMultiPlayerControlsPanel()
     {
        multiPlayerControlsPanel.SetActive(false);
        ToggleSettingsPanel(true);
     }

    
  public void ReturnToSettingsPanel()
    {
        settingsPanel.SetActive(true);
        howToPlayPanel.SetActive(false); 
        pauseMenuPanel.SetActive(false); 
    }

    public void ReturnToPausePanel()
    {
        pauseMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }

    public void ReturnToSceneOrPauseMenu(string sceneName)
    {
        
        if (string.IsNullOrEmpty(sceneName))
        {
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(true);
            }
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
