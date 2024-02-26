using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovetoNextLevel : MonoBehaviour
{
    
    public int nextSceneLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    
    // public void OntriggerEnter(Collider other)
    // {
    //     if(other.gameobject.tag == "Player")
    //     {
    //         SceneManager.LoadScene(nextSceneLoad);

    //         if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
    //         {
    //             PlayerPrefs.SetInt("levelAt", nextSceneLoad);
    //         }
    //     }
    // }
}
