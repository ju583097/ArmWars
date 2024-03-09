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

    void ExitGame()
    {
        
        Application.Quit();
    }

     public void QuitGameButton()
    {
        
        ExitGame();
    }
}      
