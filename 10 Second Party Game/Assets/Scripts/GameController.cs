using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnLocations;

    public int enemyCount;
    public int timer = 10;

    public float spawnWait;
    public float startWait;

    private bool gameOver;
    private bool restart;
    private bool backSoundPlayed;
    private bool winSoundPlayed;
    private bool lossSoundPlayed;
    private bool crashSoundPlayed;

    public Text countdownText;
    public Text startText;
    public Text winText;
    public Text lossText;

    public AudioClip background;
    public AudioClip victory;
    public AudioClip loss;
    public AudioClip crash;
    public AudioClip startup;
    public AudioSource musicSource;

    private void Start ()
    {
        StartCoroutine (SpawnWaves());
        StartCoroutine(ExecuteAfterTime());
        Time.timeScale = 1;
        startText.text = "DODGE THE CARS!";
        winText.text = "";
        lossText.text = "";
        gameOver = false;
        restart = false;
        musicSource.PlayOneShot(startup);
        backSoundPlayed = false;
        winSoundPlayed = false;
        lossSoundPlayed = false;
        crashSoundPlayed = false;
    }

    private void Update()
    {
        countdownText.text = ("" + timer);

        if (GameObject.FindWithTag("Player") == null)
        {
            StopCount();
            gameOver = true;
            restart = true;
            lossText.text = "You lose! Press SPACE to retry.";
            if (!crashSoundPlayed)
            {
                musicSource.clip = crash;
                musicSource.Play();
                crashSoundPlayed = true;
                StartCoroutine(YouLost());
            }
        }

        if (timer < 0)
        {
            StopCount();
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer--;
            if (!backSoundPlayed)
            {
                musicSource.clip = background;
                musicSource.Play();
                backSoundPlayed = true;
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, spawnLocations[Random.Range(0,3)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);

            if (gameOver)
            {
                break;
            }
        }
    }

    IEnumerator YouLost()
    {
        yield return new WaitForSeconds(1);
        musicSource.clip = loss;
        musicSource.Play();
    }

    public void StopCount()
    {
        gameOver = true;
        countdownText.text = "";
    }

    public void EndGame()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            winText.text = "You WIN! Press SPACE to replay.";
            restart = true;
            if (!winSoundPlayed)
            {
                musicSource.clip = victory;
                musicSource.Play();
                winSoundPlayed = true;
            }
        }

        if (GameObject.FindWithTag("Enemy") != null)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }
}