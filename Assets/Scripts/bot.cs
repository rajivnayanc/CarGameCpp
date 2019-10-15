using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bot : MonoBehaviour
{

    Vector3 position;

    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = Mathf.Clamp(position.x, -2.5f, 2.5f); // clamps the position of car 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
            position.x = Random.Range(-2.5f, 2.5f) * 9f * Time.deltaTime;
            transform.position = position;
        }
    }
}
