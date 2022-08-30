using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    private Transform check;

    private float xAxis;
    private bool isJumped;

    public float jumpCoff;
    public float moveCoff;

    public bool isGrounded;
    public bool walkCheck;

    private float moveInput;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat;
    public PhysicsMaterial2D normalMat;

    public bool isControl;
    public bool jumpCheck;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //animator = transform.Find("Sprite").GetComponent<Animator>();
        check = transform.Find("Check");

        xAxis = 0;
        isJumped = true;

        jumpCoff = 0;
        moveCoff = 12;

        isGrounded = false;

        walkCheck = true;
        isControl = true;

        jumpCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isGrounded == true && jumpCheck == true)
        {
            isControl = false;
            jumpCheck = false;
        }
        if(isGrounded == true && isControl == false && rb2d.velocity.x < 0.1f && jumpCheck == false)
        {
            isControl = true;
        }
        
        isGrounded = Physics2D.OverlapCircle(new Vector2(rb2d.transform.position.x, 
            rb2d.transform.position.y - 0.5f), 0.5f, groundMask);
        ActionJump();
        ActionMove();

    }

    private void FixedUpdate()

    {

        //CheckIsGrounded();
        //CheckLanded();
        SetVelocity();
        SetLocalScale();

    }


    /*
    private void CheckIsGrounded()

    {

        isGroundedPrev = isGrounded;
        isGrounded = false;

        Collider2D[] c2ds = Physics2D.OverlapCircleAll(new Vector2(rb2d.velocity.x, rb2d.velocity.y), 0.5f);

        foreach (Collider2D c2d in c2ds)
        {

            if (c2d.gameObject.layer == 7)

            {
                isGrounded = true;
                break;
            }

        }

    }



    private void CheckLanded()

    {

        if (isGrounded == true && isGroundedPrev == false && isJumped == true)

        {

            isJumped = false;
            //animator.SetTrigger("Idle");

        }

    }
    */
    private void SetVelocity()
    {
        if(isControl == true)
        {
            if (jumpCoff == 0.0f && isGrounded && isJumped)
            {

                rb2d.AddForce(new Vector2(xAxis * (moveCoff * 2), 0));

                float x = Mathf.Clamp(rb2d.velocity.x, -12, 12);
                float y = Mathf.Clamp(rb2d.velocity.y, -30, 30);

                rb2d.velocity = new Vector2(x, y);
            }
        }

     
    }



    private void SetLocalScale()

    {
        if (xAxis == 0)
            return;

        transform.localScale = new Vector3(xAxis > 0 ? 1 : -1, 1, 1);

    }

    private void ActionMove()

    {
        if(isControl == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            xAxis = Input.GetAxis("Horizontal");


            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                walkCheck = false;
            }
            else
            {
                walkCheck = true;
            }

            if (Mathf.Abs(xAxis) < 0.1f)
            {
                xAxis = 0;
                //animator.SetBool("IsWalk", false);
            }
            else
            {
                //animator.SetBool("IsWalk", true);
            }
        }
    }
    private void ActionJump()
    {   
        if(isControl == true)
        {
            if (jumpCoff > 0)
            {
                rb2d.sharedMaterial = bounceMat;
            }
            else
            {
                rb2d.sharedMaterial = normalMat;
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded && isJumped)
            {
                jumpCoff += 0.2f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isJumped)
            {
                rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y);
            }

            if (jumpCoff >= 40f && isGrounded)
            {
                float tempX = (moveCoff * 2) * xAxis;
                float tempY = jumpCoff;
                rb2d.velocity = new Vector2(tempX, tempY);
                Invoke("ResetJump", 0.2f);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (isGrounded)
                {
                    rb2d.velocity = new Vector2(xAxis * moveCoff, jumpCoff);
                    jumpCoff = 0.0f;
                }
                isJumped = true;
                jumpCheck = true;
            }
        }
        

    }

    void ResetJump()
    {
        isJumped = false;
        jumpCoff = 0;
    }
}
