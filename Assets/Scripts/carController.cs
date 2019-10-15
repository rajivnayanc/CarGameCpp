using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour {

	// Car controls
    float carSpeed = 10;
    Vector3 position;
    public UI ui;
    
	void Start ()
	{
	    position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime; // Time.deltaTime -> time took to render the last frame
        position.x = Mathf.Clamp(position.x, -2.5f, 2.5f); // clamps the position of car 
	    transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            ui.collision();
            Destroy(col.gameObject);
        }
    }
}
