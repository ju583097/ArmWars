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
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Called when a scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play the music whenever a scene is loaded
        PlayMusic();
    }

  public void PlayMusic()
{
    if (audioClips.Length > 0)
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.loop = true;

        // Enable the audio source if it's disabled
        if (!audioSource.enabled)
            audioSource.enabled = true;

        audioSource.Play();
    }
    else
    {
        Debug.LogWarning("No audio clips assigned to BackgroundMusic.");
    }
}

}
