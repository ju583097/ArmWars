using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class VersusPlayerController : MonoBehaviour
{
    public int[] playerPresses; // Array to track the button presses for each player
    public int threshold = 150; // Threshold for winning
    public GameObject winPanel; // Reference to the win panel GameObject
    private bool gameOver = false;
    private bool countdownFinished = false;
    public TMP_Text[] playerKeyBindTexts; // Array of TMP_Text for displaying key binds
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
        // Loop through player keybind texts
        for (int i = 0; i < playerKeyBindTexts.Length; i++)
        {
            // Check if the current key is pressed for each player
            if (Input.GetKeyDown(VersusKeyBindManager.Instance.GetCurrentKey(playerKeyBindTexts[i])))
            {
                // Increment the correct player's press count
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
