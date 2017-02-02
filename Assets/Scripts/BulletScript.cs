using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    public bool right = true;

    private Vector3 spawnLocation;

    // Use this for initialization
    void Start()
    {
        spawnLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    void moveBullet()
    {
        if (right)
        {
            transform.position += Vector3.left * -5 * Time.deltaTime;
        }

        else
        {
            transform.position += Vector3.left * 5 * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D()
    {
        transform.position = spawnLocation;
        GetComponent<AudioSource>().Play();
    }
}
