using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1_controller : MonoBehaviour {

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
        //position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime; // Time.deltaTime -> time took to render the last frame
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f); // clamps the position of car 
        //transform.position = position;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.MovePosition(transform.position + (transform.right * h + transform.up * v) * carSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            ui.P1_collision();
            Destroy(col.gameObject);
        }
    }
}
