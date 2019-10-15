using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Use this for initialization
    public Text s1Text;
    public Text s2Text;
    public Text tText;
    
    void Start ()
    {
        s1Text.text = "P1 Score: " + ((int)PlayerPrefs.GetFloat("Player 1 - Score")).ToString();
        s2Text.text = "P2 Score: " + ((int)PlayerPrefs.GetFloat("Player 2 - Score")).ToString();
        //tText.text = "Time: " + ((int)PlayerPrefs.GetFloat("Time")).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
