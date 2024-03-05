using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBindManager : MonoBehaviour
{
    public TextMeshProUGUI keyBindText; 
    public KeyCode defaultKey; 
    private KeyCode currentKey; 

    void Start()
    {
        currentKey = PlayerPrefs.HasKey("KeyBind") ? (KeyCode)PlayerPrefs.GetInt("KeyBind") : defaultKey;
        UpdateKeyBindText();
    }

    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode) && keyCode != currentKey)
                {
                    currentKey = keyCode;
                    PlayerPrefs.SetInt("KeyBind", (int)currentKey);
                    PlayerPrefs.Save();
                    UpdateKeyBindText();
                    break;
                }
            }
        }
    }

    void UpdateKeyBindText()
    {
        keyBindText.text = currentKey.ToString();
    }
}
