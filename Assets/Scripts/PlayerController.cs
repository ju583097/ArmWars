using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int pressesPerSecond = 5; // Number of presses per second
    public int currentPresses = 0; //Current number of presses by the player
   

    // Update is called once per frame
    void Update()
    {
        // Will check to see if the player is pressing the correct button
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentPresses++; //Increment the number of presses
            CheckWinCondition(); //Check if the player has reached the threshold
        }
    }




     void CheckWinCondition()
    {
        if (currentPresses >= 150);
    }
}
