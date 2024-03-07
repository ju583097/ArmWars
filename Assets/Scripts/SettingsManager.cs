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
        else
        {

        }
    }

    
    public void ToggleSettingsPanel(bool state)
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(state);
        }
    }

    
    public void ApplySettings()
    {
        
    }

    
   public void ShowHowToPlayPage()
  {
    if (howToPlayPanel != null)
    {
        howToPlayPanel.SetActive(true);
        
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }
  }

  
   public void ReturnFromHowToPlay()
   {
    if (settingsPanel != null && howToPlayPanel != null)
    {
        howToPlayPanel.SetActive(false); 
        settingsPanel.SetActive(true); 
    }
   }

   

    
    public void ShowSinglePlayerControlsPage()
    {
        singlePlayerControlsPanel.SetActive(true); 
        settingsPanel.SetActive(false);
    }

    public void ReturnFromSinglePlayerControlsPanel()
    {
        if (singlePlayerControlsPanel != null)
        {
            singlePlayerControlsPanel.SetActive(false);
        }
    }

    
    public void ShowVersusPlayerControlsPage()
    {
       multiPlayerControlsPanel.SetActive(true); 
        settingsPanel.SetActive(false);
    }
     public void ReturnFromMultiPlayerControlsPanel()
    {
        if (multiPlayerControlsPanel != null)
        {
            multiPlayerControlsPanel.SetActive(false);
        }
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
