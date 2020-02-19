using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        // put weird menu script here if broken
    }

    public void PlayGame()
    {
        // SceneManager.LoadScene("SCENE NAME HERE");
        Debug.Log("Played!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
