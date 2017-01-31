using UnityEngine;
using System.Collections;

public class activate : MonoBehaviour
{

    public float sec = 2f;
    public GameObject objectToActivate;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Activate", 2.0f, sec);
    }   

    void Activate ()
    {
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
