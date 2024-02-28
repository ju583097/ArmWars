using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

     public int pressesPerSecond = 5; //Number of presses per second
     public int currentPresses = 0; //Current number of presses by AI 
     public int threshold = 150; //Threshold for winning
    
    // Start is called before the first frame update
    void Start()
    {
        // Start AI button mashing
        InvokeRepeating("PressButton", 1f / pressesPerSecond, 1f / pressesPerSecond);
    }

   void PressButton()
    {
        if (currentPresses < threshold)
        {
            currentPresses++; // Increment the number of presses
            CheckWinCondition(); // Check if the AI has reached the threshold
        }
    }

    void CheckWinCondition()
    {
        if (currentPresses >= threshold)
        {
           
        }
    }
}
