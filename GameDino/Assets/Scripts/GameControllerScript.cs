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
    private Text coinText;

    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private int nextBoost = 10;
    private int obstacleCount=0;

    private int highScore = 0, yourScore = 0;

    public static bool gameStopped;
    private bool gameStart=false;

    float nextScoreIncrease = 0f;

    private int coinCount = 0;

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
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!gameStart)
        {
            StartGame();
        }
        if (!gameStopped)
            IncreaseYourScore();

        highScoreText.text = "HI     " + highScore;
        yourScoreText.text = "" + yourScore;
        coinText.text = "COIN " + coinCount;

        if (obstacleCount >= nextBoost)
        {
            BoostTime();
        }
    }

    private void StartGame()
    {
        gameStart = true;
        gameStopped = false;
        Time.timeScale = 1f;
        StartCoroutine(SpawnObstacle());
    }

    public void DinoHit(string name)
    {
        if (name == "Coin")
        {
            coinCount++;
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (yourScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", yourScore);
        }
        Time.timeScale = 0;
        gameStopped = true;
        restartButton.SetActive(true);
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        int randomObstacle = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
        StartCoroutine(SpawnObstacle());
    }

    void BoostTime()
    {
        Time.timeScale += 0.05f;
        obstacleCount = 0;
        Debug.Log(Time.timeScale);
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

    public void CountObstacle()
    {
            obstacleCount++;
    }
}
