using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int pressesPerSecond = 5; // Number of presses per second
    public int currentPresses = 0; //Current number of presses by the player
    public int threshold = 150; //Threshold for winning
    public float timeLimit = 60f; //Time limit for the game
    private float currentTime; //Current time remaining
    public Text timerText; //Reference to UI text displaying the timer

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeLimit;
        UpdateTimerDisplay();
    }
   
   
   
    // Update is called once per frame
    void Update()
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
            GameOver("Time's up!");
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
        if (currentPresses >= 150);
    }


    void GameOver(string message)
    {
        Debug.Log("Game Over!");
    }
}
