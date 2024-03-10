using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public string[] skinNames; 
    private int selectedSkin = 0;
    public GameObject playerskinPrefab;
    public TextMeshProUGUI skinNameText;
    
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateSkinNameText();
    }

    private void UpdateSkinNameText()
    {
        
        if (selectedSkin >= 0 && selectedSkin < skinNames.Length)
        {
            skinNameText.text = skinNames[selectedSkin];
        }
        else
        {
            Debug.LogWarning("Selected skin index is out of bounds!");
        }
    }

    public void NextOption()
    {
        selectedSkin = (selectedSkin + 1) % skins.Count;
        sr.sprite = skins[selectedSkin];
        UpdateSkinNameText();
    }

    public void BackOption()
    {
        selectedSkin = (selectedSkin - 1 + skins.Count) % skins.Count;
        sr.sprite = skins[selectedSkin];
        UpdateSkinNameText();
    }

    public void PlayGame()
    {
        playerskinPrefab.GetComponent<SpriteRenderer>().enabled = false;
//#if UNITY_EDITOR
   // UnityEditor.PrefabUtility.SaveAsPrefabAsset(playerskinPrefab, "Assets/SelectedSkin.prefab");
//#endif
    SceneManager.LoadScene("LevelSelection");
    }
}
