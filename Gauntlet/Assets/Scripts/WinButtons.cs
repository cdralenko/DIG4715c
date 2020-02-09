using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtons : MonoBehaviour
{
    public AudioClip soundeffect2;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = soundeffect2;
    }

    public void ClickMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void FinalQuit()
    {
        audioSource.Play();
        Application.Quit();
    }
}
