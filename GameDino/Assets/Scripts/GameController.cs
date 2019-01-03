using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int score;
    public Text scoreText;
    private int highscore;
    // Use this for initialization
    void Start () {
        score = 0;
        highscore = PlayerPrefs.GetInt("HIGHSCORE");
    }
	
	// Update is called once per frame
	void Update () {      
        score = (int)Time.time;
        scoreText.text = "HI "+ highscore + " " + score;
        if(score>highscore)
            {
                PlayerPrefs.SetInt("HIGHSCORE", score);
            }
	}
}
