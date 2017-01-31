using UnityEngine;
using System.Collections;

public class PlayerSanta : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed = 10;

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
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
    void Update()
    {
        HandleInput();
    }


	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");

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

}
