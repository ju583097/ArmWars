using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public int pressesPerSecond = 5; 
    public int currentPresses = 0; 
    public int threshold = 150; 
    public float timeLimit = 60f;
    private float currentTime;
    private bool countdownFinished = false; 
    public GameObject losePanel;
    private bool timerPaused = false; 
    void Start()
    {
        
        StartCoroutine(StartActionsAfterCountdown());
    }

    void Update()
    {
        if (!countdownFinished) 
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
                    CheckWinCondition(); 
                }
            }
        }
    }

    private IEnumerator StartActionsAfterCountdown()
    {
        yield return new WaitForSeconds(3f); 
        countdownFinished = true;

        InvokeRepeating("PressButton", 1f / pressesPerSecond, 1f / pressesPerSecond);
    }

    void PressButton()
    {
        if (!countdownFinished)
            return;

        if (currentPresses < threshold)
        {
            currentPresses++; 
            CheckWinCondition(); 
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
