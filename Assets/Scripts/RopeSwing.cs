using UnityEngine;
using System.Collections;

public class RopeSwing : MonoBehaviour {



    public bool direction = true;
    public float moveSpeed = 40.0f;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

        checkRotation();


        if (direction)
        {
            transform.Rotate(Vector3.forward, moveSpeed * Time.deltaTime );
        }
        else if(!direction)
        {
            transform.Rotate(Vector3.forward, -moveSpeed * Time.deltaTime);
        }

        

    }

    void checkRotation()
    {
        if (transform.rotation.eulerAngles.z <= 65)
        {
            direction = true;
        }
        else if (transform.rotation.eulerAngles.z >= 120)
        {
            direction = false;
        }
    }




}
