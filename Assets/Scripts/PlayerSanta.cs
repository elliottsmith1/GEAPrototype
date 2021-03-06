﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSanta : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    //public Text collectibleScore;
    public GUIText livescount;
    private int score;
    public bool isAlive = true;
    public Vector3 checkpoint_location;
    private int lives;
    public AudioClip hit;
    AudioSource source;

    [SerializeField]
    private float movementSpeed = 10f;

    private bool lookingLeft;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;
    [SerializeField]
    private bool jumpControl = false;

    [SerializeField]
    private float jumpForce;


	// Use this for initialization
	void Start () {
        lives = 5;
        UpdateLives();

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        checkpoint_location = transform.position;

        //score = 0;
        //collectibleScore.text = "Collectibles: " + score.ToString();
	}
	
    void Update()
    {
        source = GetComponent<AudioSource>();
        HandleInput();        
    }


	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");

        checkAlive();
        isGrounded = IsGrounded();
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleLayers();
        resetValues();
	}   

    private void HandleMovement(float horizontal)
    {
        if(myRigidBody.velocity.y < 0)
        {
            myAnimator.SetBool("Landing", true);
        }

        if (isGrounded || jumpControl)
        {
            myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        }
        if(isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("Jump");
        }

        myAnimator.SetFloat("PlayerSpeed", Mathf.Abs(horizontal));

    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void Flip(float horizontal)
    {
        if((horizontal < 0 && !lookingLeft || horizontal > 0 && lookingLeft) && (isGrounded || jumpControl))
        {
            lookingLeft = !lookingLeft;

            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }

    private void resetValues()
    {
        jump = false;
    }

    private bool IsGrounded()
    {
        if(myRigidBody.velocity.y <= 0)
        {
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("Jump");
                        myAnimator.SetBool("Landing", false);
                        return true;
                    }
                }
            }
        }   return false;
    }   

    private void HandleLayers()
    {
        if(!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            source.PlayOneShot(hit, .5f);
            isAlive = false;
            TakeLife(1);
        }
    }

   public void TakeLife(int newLivesValue)
    {
        lives -= newLivesValue;
        UpdateLives();
    }
    void UpdateLives()
    {
        livescount.text = "Lives left: " + lives;
    }
    private void checkAlive()
    {
        if (!isAlive)
        {
            if (lives < 1)
            {
                Application.LoadLevel("GameOver");
            }

            transform.position = checkpoint_location;
            isAlive = true;
        }
    }

}
