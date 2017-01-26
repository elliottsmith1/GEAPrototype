using UnityEngine;
using System.Collections;

public class RopeSwing : MonoBehaviour {



    public bool direction = true;
    private float startRotation;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation.z;

	
	}
	
	// Update is called once per frame
	void Update () {

        //checkRotation();


        //if(direction)
        //{
        //  transform.Rotate(Vector3.forward * 1);
        //}
        //else
        //{
        //    transform.Rotate(Vector3.forward * -1);
        //}

        //transform.rotation = Quaternion.Euler(0, 0, Mathf.PingPong(Time.time * 80, 90));







    }






}
