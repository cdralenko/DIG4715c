using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioClip soundeffect;
    public AudioSource audioSource;

    private void Start()
    {
        SceneManager.UnloadSceneAsync("WinScreen");
        SceneManager.LoadScene("MainMenu");

        audioSource.clip = soundeffect;
    }

    public void PlayGame()
    {
        audioSource.Play();
        SceneManager.LoadScene("Gauntlet");
    }

    public void QuitGame()
    {
        audioSource.Play();
        Application.Quit();
    }
}
