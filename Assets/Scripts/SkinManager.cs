using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class SkinManager : MonoBehaviour
{

    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public string[] skinNames; 
    private int selectedSkin = 0;
    public GameObject playerskinPrefab;
    public TextMeshProUGUI skinNameText;
    
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
#if UNITY_EDITOR
    UnityEditor.PrefabUtility.SaveAsPrefabAsset(playerskinPrefab, "Assets/SelectedSkin.prefab");
#endif
    SceneManager.LoadScene("LevelSelection");
    }
}
