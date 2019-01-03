using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {
    public static GameControllerScript instance = null;
    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private Text highScoreText;

    [SerializeField]
    private Text yourScoreText;

    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float spawnRate = 2f;
    private float nextSpawn;

    [SerializeField]
    private float timeToBoost = 5f;
    float nextBoost;

    int highScore = 0, yourScore = 0;

    public static bool gameStopped;
    private bool gameStart=false;

    float nextScoreIncrease = 0f;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        restartButton.SetActive(false);
        yourScore = 0;
        gameStopped = true;
        Time.timeScale = 0f;
        nextSpawn = Time.time + spawnRate;
        nextBoost = Time.unscaledTime + timeToBoost;
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!gameStart)
        {
            gameStart = true;
            gameStopped = false;
            Time.timeScale = 1f;
        }
        if(!gameStopped)
            IncreaseYourScore();

        highScoreText.text = "HI     " + highScore;
        yourScoreText.text = "" + yourScore;

        if (Time.time > nextSpawn)
            SpawnObstacle();

        if (Time.unscaledTime > nextBoost && !gameStopped)
            BoostTime();
    }

    public void DinoHit()
    {
        if(yourScore>highScore)
        {
            PlayerPrefs.SetInt("highScore", yourScore);
        }
        Time.timeScale = 0;
        gameStopped = true;
        restartButton.SetActive(true);
    }

    void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate;
        int randomObstacle = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
    }

    void BoostTime()
    {
        nextBoost = Time.unscaledTime + timeToBoost;
        Time.timeScale += 0.25f;
    }

    void IncreaseYourScore()
    {
        if(Time.unscaledTime>nextScoreIncrease)
        {
            yourScore += 1;
            nextScoreIncrease = Time.unscaledTime + 1;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
