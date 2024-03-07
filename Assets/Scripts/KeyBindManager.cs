using UnityEngine;
using TMPro;
using System;

public class KeyBindManager : MonoBehaviour
{
    public static KeyBindManager Instance; 

    public TMP_Text keyBindText; 
    private KeyCode currentKeyCode; 

    private bool isChangingKey = false; 

    
    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
        }
        

        if (PlayerPrefs.HasKey("KeyBind"))
     {
        string savedKeyBind = PlayerPrefs.GetString("KeyBind");
        if (Enum.TryParse(savedKeyBind, out KeyCode savedKeyCode))
        {
            currentKeyCode = savedKeyCode;
            UpdateKeybindText();
        }

     }
    }

    
    void Update()
    {
        
        if (isChangingKey && Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    currentKeyCode = keyCode;
                    keyBindText.text = currentKeyCode.ToString();
                    isChangingKey = false; 
                    SaveKeyBind(); 
                    break;
                }
            }
        }
    }

    
    public void ChangeKeyBind()
    {
        isChangingKey = true; 
    }

    
    private void SaveKeyBind()
    {
        
    }

      public KeyCode GetCurrentKey()
    {
        return currentKeyCode;
    }

   void UpdateKeybindText()
  {
    if (keyBindText != null)
    {
        keyBindText.text = currentKeyCode.ToString();
    }
    else
    {
        Debug.LogWarning("");
    }
  }
    
    public void ApplyKeyBind()
    {
        Debug.Log("Key bind applied: " + currentKeyCode);
        PlayerPrefs.SetString("KeyBind", currentKeyCode.ToString());
    }
}
