using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2_controller : MonoBehaviour {

	// Car controls
    float carSpeed = 10;
    Vector3 position;
    public UI ui;
    Rigidbody2D rb;

    void Start ()
	{
        rb = GetComponent<Rigidbody2D>();
	    position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        //position.x += Input.GetAxis("horizontal") * carSpeed * Time.deltaTime; // Time.deltaTime -> time took to render the last frame
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f); // clamps the position of car 
        //transform.position = position;

        float h = Input.GetAxis("horizontal");
        float v = Input.GetAxis("vertical");

        rb.MovePosition(transform.position + (transform.right * h + transform.up * v) * carSpeed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            ui.P2_collision();
            Destroy(col.gameObject);
        }
    }
}
