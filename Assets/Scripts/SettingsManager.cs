using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    // Singleton instance
    public static SettingsManager Instance;

    
    public GameObject settingsPanel;

    public GameObject howToPlayPanel;

    
    public GameObject pauseMenuPanel;

    
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;

    

    // Awake is called before Start
    void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
        
    }

    
    public void ShowVersusPlayerControlsPage()
    {
       
    }

    
   public void ReturnToSettingsPanel()
   {
    if (settingsPanel != null)
    {
        settingsPanel.SetActive(true);
    }

    
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
