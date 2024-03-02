using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public int pressesPerSecond = 5; //Number of presses per second
    public int currentPresses = 0; //Current number of presses by AI
    public int threshold = 150; //Threshold for winning
    public float timeLimit = 60f;
    private float currentTime;
    private bool countdownFinished = false; //Tracks if countdown has finished
    public GameObject losePanel;
    private bool timerPaused = false; 
    void Start()
    {
        //Start the countdown coroutine
        StartCoroutine(StartActionsAfterCountdown());
    }

    void Update()
    {
        if (!countdownFinished) //If the countdown hasn't finished, don't execute AI logic
            return;

        
        if (currentPresses < threshold && !timerPaused)
        {
           
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    currentTime = timeLimit;
                    currentPresses++;
                    CheckWinCondition(); //Checks if the AI has reached the threshold after each press
                }
            }
        }
    }

    private IEnumerator StartActionsAfterCountdown()
    {
        //Waits for the countdown to finish before starting AI actions
        yield return new WaitForSeconds(3f); 
        countdownFinished = true;

        //Starts the AI button mashing after the countdown finishes
        InvokeRepeating("PressButton", 1f / pressesPerSecond, 1f / pressesPerSecond);
    }

    void PressButton()
    {
        if (!countdownFinished) //Ensures that the AI actions don't start until after countdown finishes
            return;

        if (currentPresses < threshold)
        {
            currentPresses++; //Increment the number of presses
            CheckWinCondition(); //Check if the AI has reached the threshold
        }
    }

    void CheckWinCondition()
    {
        if (currentPresses >= threshold)
        {
            LoseGame();
           
        }
    }


    void LoseGame()
{
    losePanel.SetActive(true); 
    timerPaused = true;
    CancelInvoke("PressButton"); 
}

}
