using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    private bool isMusicPlaying = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Find the GameObject named "MarsTelkom"
        GameObject marsTelkomObject = GameObject.Find("MarsTelkom");

        if (marsTelkomObject != null)
        {
            // Get the AudioSource component from the found GameObject
            audioSource = marsTelkomObject.GetComponent<AudioSource>();

            // Start playing the music initially
            PlayMusic();
        }
        else
        {
            Debug.LogError("GameObject named 'MarsTelkom' not found!");
        }
    }

    private void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            isMusicPlaying = true;
        }
    }

    private void ReplayMusic()
    {
        if (isMusicPlaying == false)
        {
            audioSource.Play();
            isMusicPlaying = true;
        }
    }

    private void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
            isMusicPlaying = false;
        }
    }

    private void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            isMusicPlaying = false;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string[] scenesToStop = { "2. Splashscreen", "2.1. Splashscreen", "P.Menejemen Pemasaran", "P.Perhotelan", "P.RPLA", "P.SIA", "P.Sistem Informasi", "P.Teknologi Komputer", "P.Teknologi Telekomunikasi", "P.TRM" };

        if (Array.Exists(scenesToStop, s => s == scene.name))
        {
            // Stop the music for specified scenes
            PauseMusic();
        }

        else if (scene.name == "1. OnBoarding")
        {
            StopMusic();
        }

        else if (scene.name == "1. OnBoarding")
        {
            StopMusic();
        }

        else if (scene.name == "3. Main Menu")
        {
            ReplayMusic();
        }

        else
        {
            // Play the music for other scenes
            if (!isMusicPlaying)
            {
                PlayMusic();
            }
        }
    }
}
