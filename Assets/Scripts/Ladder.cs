using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
    //private PlayerMovement player;
    public float speed = 6;
	// Use this for initialization
	void Start () {
        //player = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.tag == "Player")
    //    {
    //        player.on_ladder = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.tag == "Player")
    //    {
    //        player.on_ladder = false;
    //    }
    //}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
            {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, speed);
        }

       else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -speed);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
        }
     }
}
