using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
    public float speed = 6;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed - 1);
        }

        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }

        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().drag = 50f;
            other.GetComponent<Rigidbody2D>().angularDrag = 50f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().drag = 0f;
            other.GetComponent<Rigidbody2D>().angularDrag = 0.5f;
        }
    }
}
