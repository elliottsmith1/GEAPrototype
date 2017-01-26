using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public Transform destination = null;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

   //destination : Transform;


void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = destination.position;
    }
}
