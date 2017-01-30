using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;

	void Start()
    {
	    target = GameObject.Find("Player");
	}
	
	void Update()
    {
        Vector3 temp = target.transform.position;
        temp.z = -10;
        temp.y = 4;
        transform.position = temp;
	}
}
