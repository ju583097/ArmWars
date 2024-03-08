using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    public AudioSource audioSource;

    public AudioClip[] audioClips;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

      
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic(0);
                break;
            case "CharacterSelect":
                PlayMusic(1);
                break;
                case "LevelSelection":
                PlayMusic(2);
                break;
            case "GameScreen":
                PlayMusic(3);
                break;
                case "lvl2":
                PlayMusic(4);
                break;
                case "lvl3":
                PlayMusic(5);
                break;
                case "lvl4":
                PlayMusic(6);
                break;
                case "lvl5":
                PlayMusic(7);
                break;
                case "lvl6":
                PlayMusic(8);
                break;
                 case "lvl7":
                PlayMusic(9);
                break;
                 case "lvl8":
                PlayMusic(10);
                break;
                  case "lvl9":
                PlayMusic(11);
                break;
                 case "lvl10":
                PlayMusic(12);
                break;
                case "VersusMode":
                PlayMusic(13);
                break;
            default:
                break;
        }
    }

    private void PlayMusic(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio clip index: " + clipIndex);
        }
    }
}
