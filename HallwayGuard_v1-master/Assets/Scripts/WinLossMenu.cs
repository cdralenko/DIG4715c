using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossMenu : MonoBehaviour
{

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MenuQuit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
