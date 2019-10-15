using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMove : MonoBehaviour {

	// Use this for initialization
    public float speed;

    // moving the texture upon quad
    private Vector2 offset; 
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2(Time.time * speed, 0); // increase the value depending upon the time i.e with how much speed the track will move
	    GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
