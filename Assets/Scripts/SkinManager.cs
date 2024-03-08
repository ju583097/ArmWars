using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;


public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public List<string> skinNames = new List<string>();
    private int selectedSkin = 0;
    public GameObject playerskin;
    public TextMeshProUGUI skinNameText; 

    private void Start()
    {
        UpdateSkinInfo();
    }

    public void NextOption()
    {
        selectedSkin = (selectedSkin + 1) % skins.Count;
        UpdateSkinInfo();
    }

    public void BackOption()
    {
        if (skins.Count == 0)
        {
            
            return;
        }

        selectedSkin = (selectedSkin - 1 + skins.Count) % skins.Count;
        UpdateSkinInfo();
    }

    public void PlayGame()
    {
        GameObject selectedSkinInstance = Instantiate(playerskin);
        PrefabUtility.SaveAsPrefabAsset(selectedSkinInstance, "Assets/SelectedSkin.prefab");
        SceneManager.LoadScene("LevelSelection");
    }

    private void UpdateSkinInfo()
    {
        sr.sprite = skins[selectedSkin];
        skinNameText.text = skinNames[selectedSkin]; 
    }
}
