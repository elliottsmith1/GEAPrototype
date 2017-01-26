using UnityEngine;
using System.Collections;

public class ForceWeight : MonoBehaviour {


    public bool direction;
    private Rigidbody2D weightBody;

	// Use this for initialization
	void Start () {
        direction = true;
        weightBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("addForce", 0.0f, 0.80f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void addForce()
    {
        if(direction)
        {
           weightBody.AddForce(transform.right * 5000);
        }
        else
        {
            weightBody.AddForce(transform.right * -5000);
        }

        direction = !direction;
    }
}
