using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskinPrefab;

    public void NextOption()
    {
        selectedSkin = (selectedSkin + 1) % skins.Count;
        sr.sprite = skins[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin = (selectedSkin - 1 + skins.Count) % skins.Count;
        sr.sprite = skins[selectedSkin];
    }

    public void PlayGame()
    {
        
        GameObject selectedSkinInstance = Instantiate(playerskinPrefab);

       
#if UNITY_EDITOR
        UnityEditor.PrefabUtility.SaveAsPrefabAsset(selectedSkinInstance, "Assets/Prefabs/SelectedSkin.prefab");
#endif

        
        SceneManager.LoadScene("LevelSelection");
    }
}
