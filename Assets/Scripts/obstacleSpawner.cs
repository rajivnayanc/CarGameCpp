using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour {

	// Use this for initialization
    public GameObject[] obstacles;
    int obstacleNo;
    public float maxPos = 2.5f;

    public float delayTimer = 3f;
    float timer;

	void Start ()
	{
	    timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer -= Time.deltaTime;

	    if (timer <= 0)
	    {
	        Vector3 carPos = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, transform.position.z);
	        obstacleNo = Random.Range(0,2);
	        Instantiate(obstacles[obstacleNo], carPos, transform.rotation);
	        timer = delayTimer;
	    }
	}
}
