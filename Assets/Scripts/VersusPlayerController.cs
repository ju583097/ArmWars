using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VersusPlayerController : MonoBehaviour
{
    public KeyCode[] playerKeys; //Array of the key codes for each player
    public int[] playerPresses; //Array to track the button presses for each player
    public int threshold = 150; //Threshold for winning
    public GameObject winPanel; //Reference to the win panel GameObjects for each player
    private bool gameOver = false; 
    private bool countdownFinished = false; 
    public TextMeshProUGUI countdownText; 
    public int currentPresses = 0; 

    void Start()
    {
        StartCoroutine(StartCountdown()); 
    }

    void Update()
    {
        if (!gameOver && countdownFinished) 
        {
            
            for (int i = 0; i < playerKeys.Length; i++)
            {
                if (Input.GetKeyDown(playerKeys[i]))
                {
                    playerPresses[i]++;
                    currentPresses++; 
                    CheckWinCondition(); 
                }
            }
        }
    }

    IEnumerator StartCountdown()
    {
        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownFinished = true; 
        countdownText.gameObject.SetActive(false);
    }

    void CheckWinCondition()
    {
        for (int i = 0; i < playerPresses.Length; i++)
        {
            if (playerPresses[i] >= threshold)
            {
                WinGame(i + 1); 
                return; 
            }
        }
    }

    void WinGame(int playerNumber)
    {
        winPanel.SetActive(true); 
        gameOver = true; 
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
