using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text WinText;
    public Text CreatedText;
    public Text HardText;
    public Text TimeText;

    private bool gameOver;
    private bool restart;
    public bool Win = false;
    public static bool Hard = false;
    public static bool Time = false;
    public static bool Normal = true;
    private int score;

    GameObject HardHazard;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Hard == true)
        {
            hazardCount = 20;  
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("Main");
                Hard = true;
                Normal = false;
                Time = false;
            }
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Main");
                Time = true;
                Normal = false;
                Hard = false;
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'P' to play again";
                HardText.text = "Press 'H' to play Hard Mode";
                TimeText.text = "Press 'T' to play Time Attack";
                restart = true;
                break;
            }      
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
     {
        ScoreText.text = "Points: " + score;
        if (Normal == true)
        {
            if (score >= 100)
            {
                WinText.text = "You Win!";
                CreatedText.text = "Game Created By: Andrew Freitas";
                Win = true;
                gameOver = true;
                restart = true;
            }
        }

        if (Hard == true)
        {
            if (score >= 500)
            {
                WinText.text = "You Win!";
                CreatedText.text = "Game Created By: Andrew Freitas";
                Win = true;
                gameOver = true;
                restart = true;            }
        }

        if (Time == true)
        {
            if (Countdown.currentTime == 0)
            {
                WinText.text = "You Win!";
                CreatedText.text = "Game Created By: Andrew Freitas";
                Win = true;
                gameOver = true;
                restart = true;
            }
        }
      }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}