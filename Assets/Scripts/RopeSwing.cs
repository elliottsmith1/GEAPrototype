using UnityEngine;
using System.Collections;

public class RopeSwing : MonoBehaviour {



    public bool direction = true;
    private float rotationSpeed = 25;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

        checkRotation();


        if (direction)
        {
            transform.Rotate (Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }


    }


    void checkRotation()
    {

        if(transform.rotation.eulerAngles.z <= 65)
        {
            direction = true;
        }
        else if(transform.rotation.eulerAngles.z >= 125)
        {
            direction = false;
        }



    }



}
