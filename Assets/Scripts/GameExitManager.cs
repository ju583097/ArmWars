using UnityEngine;

public class GameExitManager : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            ExitGame();
        }
    }

    public void ExitGame()
    {
        
        Application.Quit();
    }

    
}      
