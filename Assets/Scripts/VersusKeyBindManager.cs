using UnityEngine;
using TMPro;
using System;

public class VersusKeyBindManager : MonoBehaviour
{
    public static VersusKeyBindManager Instance;

    public TMP_Text keyBindText;
    public TMP_Text player1KeyBindText;
    public TMP_Text player2KeyBindText;

    private KeyCode currentPlayer1KeyCode;
    private KeyCode currentPlayer2KeyCode;

    private bool isChangingKeyPlayer1 = false;
    private bool isChangingKeyPlayer2 = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadKeyBindings();
    }

    void LoadKeyBindings()
    {
        if (PlayerPrefs.HasKey("Player1KeyBind"))
        {
            string savedKeyBind = PlayerPrefs.GetString("Player1KeyBind");
            if (Enum.TryParse(savedKeyBind, out KeyCode savedKeyCode))
            {
                currentPlayer1KeyCode = savedKeyCode;
                UpdateKeybindText(player1KeyBindText, currentPlayer1KeyCode);
            }
        }

        if (PlayerPrefs.HasKey("Player2KeyBind"))
        {
            string savedKeyBind = PlayerPrefs.GetString("Player2KeyBind");
            if (Enum.TryParse(savedKeyBind, out KeyCode savedKeyCode))
            {
                currentPlayer2KeyCode = savedKeyCode;
                UpdateKeybindText(player2KeyBindText, currentPlayer2KeyCode);
            }
        }
    }

    void Update()
    {
        if ((isChangingKeyPlayer1 || isChangingKeyPlayer2) && Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    if (isChangingKeyPlayer1)
                    {
                        currentPlayer1KeyCode = keyCode;
                        UpdateKeybindText(player1KeyBindText, currentPlayer1KeyCode);
                        isChangingKeyPlayer1 = false;
                        SaveKeyBind("Player1KeyBind", currentPlayer1KeyCode);
                    }
                    else if (isChangingKeyPlayer2)
                    {
                        currentPlayer2KeyCode = keyCode;
                        UpdateKeybindText(player2KeyBindText, currentPlayer2KeyCode);
                        isChangingKeyPlayer2 = false;
                        SaveKeyBind("Player2KeyBind", currentPlayer2KeyCode);
                    }
                    break;
                }
            }
        }
    }

    public void ChangeKeyBindPlayer1()
    {
        isChangingKeyPlayer1 = true;
    }

    public void ChangeKeyBindPlayer2()
    {
        isChangingKeyPlayer2 = true;
    }

    private void SaveKeyBind(string playerPrefsKey, KeyCode keyCode)
    {
        PlayerPrefs.SetString(playerPrefsKey, keyCode.ToString());
    }

    void UpdateKeybindText(TMP_Text keyBindText, KeyCode keyCode)
    {
        if (keyBindText != null)
        {
            keyBindText.text = keyCode.ToString();
        }
        else
        {
            Debug.LogWarning("keyBindText is not assigned. Make sure to assign it in the Inspector.");
        }
    }

    public void ApplyKeyBind()
    {
        PlayerPrefs.SetString("Player1KeyBind", currentPlayer1KeyCode.ToString());
        PlayerPrefs.SetString("Player2KeyBind", currentPlayer2KeyCode.ToString());
    }

    public KeyCode GetCurrentKey(TMP_Text keyBindText)
    {
        KeyCode keyCode;
        if (Enum.TryParse(keyBindText.text, out keyCode))
        {
            return keyCode;
        }
        else
        {
            Debug.LogError("Invalid player key: " + keyBindText.text);
            return KeyCode.None; // Return a default key or handle the error as needed
        }
    }
}
