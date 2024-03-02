using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public int pressesPerSecond = 5; // Number of presses per second
    public int currentPresses = 0; //Current number of presses by the player
    public int threshold = 150; //Threshold for winning
    public float timeLimit = 60f; //Time limit for the game
    private float currentTime; //Current time remaining
   public TextMeshProUGUI timerText; //Reference to TextMeshProUGUI for displaying timer
    public AIController aiController; //Reference to AI controller script
    public TextMeshProUGUI countdownText; //Reference to TextMeshProUGUI for displaying intial countdown
    public float countdownDuration = 3f;
    public GameObject winPanel; 
    public GameObject losePanel;
    public Button nextLevelButton; 
    public Button retryButton;
    private bool gameOver = false; //Tracking the game to make sure timer does not continue after game is over
    private bool countdownFinished = false; //Tracks if countdown has finished

    // Start is called before the first frame update
    void Start()
    {
        StartCountdown(); //Start the countdown when the game starts
        currentTime = timeLimit;
        UpdateTimerDisplay();
    }
   
   
   
    // Update is called once per frame
    void Update()
    {
      if (!gameOver && countdownFinished  &&  !losePanel.activeSelf) //Only update time if the game is not over and allow game logic after countdown finishes and pauses timer on loss
      {
        currentTime -= Time.deltaTime; //Decrement current time
        UpdateTimerDisplay(); //Update UI timer display

        // Will check to see if the player is pressing the correct button
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentPresses++; //Increment the number of presses
            CheckWinCondition(); //Check if the player has reached the threshold
        }

        //Check if time is up
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
            timerText.text = Mathf.CeilToInt(currentTime).ToString(); //Update UI text with remaining time
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
        enabled = false; //Disables player controller when win panel gets active
        
    }

    void LoseGame()
    {
        
        losePanel.SetActive(true);
        enabled = false; //Disables player controller when win panel gets active

    }
   public void NextLevel()
{
    int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    SceneManager.LoadScene(nextSceneLoad);

    //Updates the highest level completed in PlayerPrefs 
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
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "WRESTLE!";
        yield return new WaitForSeconds(1f);

        countdownFinished = true; // Set countdownFinished to true
        StartGame();
    }

    void StartGame()
    {
        // Implement logic to start the game or transition to the next scene
        Debug.Log("Game started!");

         // Activate player controller
         GetComponent<PlayerController>().enabled = true;
    
         // Activate AI controller
         aiController.enabled = true;
    
         // Optionally, reset any game variables
        currentPresses = 0;
        currentTime = timeLimit;
    
        // Optionally, reset UI elements
        UpdateTimerDisplay();
        countdownText.text = "";
       

    
    }
}
