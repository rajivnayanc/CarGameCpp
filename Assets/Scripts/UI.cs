using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	// Use this for initialization
    public Text Score_p1;
    public Text Score_p2;
    public Text timeText;
    public int P1_score;
    public int P2_score;
    public int time;

	void Start ()
	{
	    P1_score = 0;
        P2_score = 0;
        time = 0;
	    InvokeRepeating("updateTime", 1.0f, 1.0f);
       
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Score_p1.text = "Score P1: " + P1_score;
        Score_p2.text = "Score P2: " + P2_score;
        timeText.text = "Time: " + time;

        if (time >= 10)
	    {
	        Time.timeScale = 0;
	        PlayerPrefs.SetFloat("Player 1 - Score", P1_score);
            PlayerPrefs.SetFloat("Player 2 - Score", P2_score);
            PlayerPrefs.SetFloat("Time", time);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

    }

    void updateTime()
    {
        time += 1;
    }

    public void P1_collision()
    {
        P1_score += 5;
    }

    public void P2_collision()
    {
        P2_score += 5;
    }
}
