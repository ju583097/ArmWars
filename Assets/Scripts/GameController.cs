using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public AIController aiController;
    public SpriteRenderer backgroundSpriteRenderer; 
    public Color playerWinColor; 
    public Color aiWinColor; 
    public float alphaThreshold = 0.5f; 

   
    void Update()
    {
        
        if (playerController.currentPresses > aiController.currentPresses)
        {
            AdjustBackgroundOpacity(playerWinColor);
        }
        else if (aiController.currentPresses > playerController.currentPresses)
        {
            AdjustBackgroundOpacity(aiWinColor);
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
