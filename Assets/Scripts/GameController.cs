using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public AIController aiController;
    public SpriteRenderer backgroundSpriteRenderer; //Reference to the SpriteRenderer component of the background GameObject
    public Color playerWinColor; //Color for when the player is winning
    public Color aiWinColor; //Color for when the AI is winning
    public float alphaThreshold = 0.5f; //Threshold for adjusting sprite opacity

    // Update is called once per frame
    void Update()
    {
        //Check who's currently winning
        if (playerController.currentPresses > aiController.currentPresses)
        {
            //Player is winning, adjust background opacity to simulate playerWinColor
            AdjustBackgroundOpacity(playerWinColor);
        }
        else if (aiController.currentPresses > playerController.currentPresses)
        {
            //AI is winning, adjust background opacity to simulate aiWinColor
            AdjustBackgroundOpacity(aiWinColor);
        }
        else
        {
            //If neither is winning (tie or no presses yet), keep the default background color
            AdjustBackgroundOpacity(Color.white); //Change to your default background color
        }
    }

    void AdjustBackgroundOpacity(Color color)
    {
        if (backgroundSpriteRenderer != null)
        {
            //Change the color property of the SpriteRenderer component
            Color currentColor = color;
            currentColor.a = alphaThreshold; //Set the alpha channel of the color to the threshold value
            backgroundSpriteRenderer.color = currentColor;
        }
        
    }
}
