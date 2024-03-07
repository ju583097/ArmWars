using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class VersusPlayerController : MonoBehaviour
{
    public int[] playerPresses; 
    public int threshold = 150; 
    public GameObject winPanel; 
    private bool gameOver = false;
    private bool countdownFinished = false;
    public TMP_Text[] playerKeyBindTexts; 
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
        
        for (int i = 0; i < playerKeyBindTexts.Length; i++)
        {
            
            if (Input.GetKeyDown(VersusKeyBindManager.Instance.GetCurrentKey(playerKeyBindTexts[i])))
            {
                
                if (i < playerPresses.Length)
                {
                    playerPresses[i]++;
                    currentPresses++;
                    CheckWinCondition();
                }
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
