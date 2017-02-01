using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public GUIText scoreText;
    private int score;
    private int spriteNum = 4;
    public Sprite grey;
    public Sprite green;
    public Sprite blue;
    public Sprite red;
    public Sprite yellow;

    // Use this for initialization
    void Start ()
    {
        score = 10;
        UpdateScore();
        InvokeRepeating("ChangeSprite", 0.2f, 0.2f);
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

    void ChangeSprite()
    {
        if (spriteNum == 1)
        {
            GetComponent<SpriteRenderer>().sprite = grey;
            spriteNum = 2;
        }

        else if (spriteNum == 2)
        {
            GetComponent<SpriteRenderer>().sprite = green;
            spriteNum = 3;
        }

        else if (spriteNum == 3)
        {
            GetComponent<SpriteRenderer>().sprite = blue;
            spriteNum = 4;
        }

        else if (spriteNum == 4)
        {
            GetComponent<SpriteRenderer>().sprite = red;
            spriteNum = 5;
        }

        else if (spriteNum == 5)
        {
            GetComponent<SpriteRenderer>().sprite = yellow;
            spriteNum = 1;
        }
    }
}
