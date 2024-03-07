using UnityEngine;
using TMPro;

public class VersusGameController : MonoBehaviour
{
    public VersusPlayerController[] playerControllers; 
    public SpriteRenderer backgroundSpriteRenderer; 
    public Color player1WinColor; 
    public Color player2WinColor; 
    public float alphaThreshold = 0.5f; 

    
    void Update()
    {
        
        if (playerControllers[0].currentPresses > playerControllers[1].currentPresses)
        {
            AdjustBackgroundOpacity(player1WinColor);
        }
        else if (playerControllers[1].currentPresses > playerControllers[0].currentPresses)
        {
            AdjustBackgroundOpacity(player2WinColor);
        }
        else
        {
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
