using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public int pressesPerSecond = 5; 
    public int currentPresses = 0; 
    public int threshold = 150; 
    public float timeLimit = 60f; 
    private float currentTime; 
    public TextMeshProUGUI timerText; 
    public AIController aiController; 
    public TextMeshProUGUI countdownText; 
    public float countdownDuration = 3f;
    public GameObject winPanel; 
    public GameObject losePanel;
    public Button nextLevelButton; 
    public Button retryButton;
    private bool gameOver = false; 
    private bool countdownFinished = false; 
    public KeyBindManager keyBindManager;
    public TextMeshProUGUI tutorialText;

   
    void Start()
    {
        keyBindManager = KeyBindManager.Instance;
        StartCountdown(); 
        currentTime = timeLimit;
        UpdateTimerDisplay();
    }
   
   
   
    
    void Update()
    {
      if (!gameOver && countdownFinished  &&  !losePanel.activeSelf) 
      {
        currentTime -= Time.deltaTime; 
        UpdateTimerDisplay(); 

        KeyCode currentKey = keyBindManager.GetCurrentKey(); 
       
        if (Input.GetKeyDown(currentKey))
        {
            currentPresses++; 
            CheckWinCondition(); 
        }

        
        if (currentTime <= 0)
        {
            LoseGame();
        }
      }
    }




    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(currentTime).ToString(); 
        }
    }

     void CheckWinCondition()
    {
        if (currentPresses >= 150)
        {
            WinGame();
        }
        else if (aiController.currentPresses >= threshold)
        {
            LoseGame();
        }
    }



    void WinGame()
    {
        winPanel.SetActive(true);
        enabled = false; 
        
    }

    void LoseGame()
    {
        
        losePanel.SetActive(true);
        enabled = false; 

    }
   public void NextLevel()
{
    int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    SceneManager.LoadScene(nextSceneLoad);

     
    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
    {
        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
    }
}


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }


   




void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private System.Collections.IEnumerator CountdownCoroutine()
    {
        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            tutorialText.text = "Mash F to win!";
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "WRESTLE!";
        tutorialText.text = "";
        yield return new WaitForSeconds(1f);

        countdownFinished = true; 
        StartGame();
    }

    void StartGame()
    {
        GetComponent<PlayerController>().enabled = true;
    
        aiController.enabled = true;
    
        currentPresses = 0;
        currentTime = timeLimit;
    
        UpdateTimerDisplay();
        countdownText.text = "";
      
    }
}
