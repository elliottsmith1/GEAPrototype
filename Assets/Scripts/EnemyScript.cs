using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public float positionOne = 0;
    public float positionTwo = 0;
    bool moveDirection = false;
    public bool UpDown = false;
    public bool rotating = false;
    public int speed = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        checkPosition();
        moveEnemy();
	
	}

    //function to kill player when script is implemented
   /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerScript>().health = 0;
        }
    }*/

    void moveEnemy()
    {
        if (!UpDown)
        {
            if (moveDirection)
            {
                transform.position += Vector3.left * -speed * Time.deltaTime;
            }

            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }

        else
        {
            if (moveDirection)
            {
                transform.position += Vector3.up * -speed * Time.deltaTime;
            }

            else
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }

        if (rotating)
        {
            transform.Rotate(Vector3.forward * 15);
        }
    }

    void checkPosition()
    {
        if (!UpDown)
        {
            if (transform.position.x < positionOne)
            {
                moveDirection = true;
            }

            else if (transform.position.x > positionTwo)
            {
                moveDirection = false;
            }
        }

        else
        {
            if (transform.position.y > positionOne)
            {
                moveDirection = true;
            }

            else if (transform.position.y < positionTwo)
            {
                moveDirection = false;
            }
        }
    }
}
