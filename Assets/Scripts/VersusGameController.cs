using UnityEngine;
using TMPro;

public class VersusGameController : MonoBehaviour
{
    public VersusPlayerController[] playerControllers; //Array of VersusPlayerController scripts for each player
    public SpriteRenderer backgroundSpriteRenderer; 
    public Color player1WinColor; //Color for when player 1 is winning
    public Color player2WinColor; //Color for when player 2 is winning
    public float alphaThreshold = 0.5f; 

    // Update is called once per frame
    void Update()
    {
        //Check who's currently winning
        if (playerControllers[0].currentPresses > playerControllers[1].currentPresses)
        {
            //Player 1 is winning, adjust background opacity to player1WinColor
            AdjustBackgroundOpacity(player1WinColor);
        }
        else if (playerControllers[1].currentPresses > playerControllers[0].currentPresses)
        {
            //Player 2 is winning, adjust background opacity to player2WinColor
            AdjustBackgroundOpacity(player2WinColor);
        }
        else
        {
            //If neither player is winning (tie or no presses yet), keep the default background color
            AdjustBackgroundOpacity(Color.white); 
        }
    }

    void AdjustBackgroundOpacity(Color color)
    {
        if (backgroundSpriteRenderer != null)
        {
            Color currentColor = color;
            currentColor.a = alphaThreshold; 
            backgroundSpriteRenderer.color = currentColor;
        }
    }
}
