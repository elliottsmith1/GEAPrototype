﻿using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public GUIText scoreText;
    private int score;
    
    // Use this for initialization
    void Start ()
    {
        score = 20;
        UpdateScore();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectable")
        {
            GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
            AddScore(1);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score -= newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Gems to oollect: " + score;
    }    
}
