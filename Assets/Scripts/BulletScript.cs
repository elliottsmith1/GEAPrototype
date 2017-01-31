using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

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
        transform.position += Vector3.left * 5 * Time.deltaTime;
    }

    void OnTriggerEnter2D()
    {
        transform.position = spawnLocation;
    }
}
