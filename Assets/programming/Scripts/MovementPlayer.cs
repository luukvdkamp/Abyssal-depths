using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 movement;
    public Rigidbody playerRigidbody;
    public bool isGrounded;
    public float speedCount;
    public bool jumping;

    [Header("Speed values")]
    public float speed;
    public float airSpeed;

    public float jumpSpeed;
    public float jumpSideSpeed;

    public float jumpResetTime;
    private float jumpResetCounter;

    public float gravity;
    public float gravityMultiplier;

    [Header("Player Animation")]
    public PlayerAnimations playerAnimations;



    private void Start()
    {
        
    }

    void Update()
    {
        //horizontal movement, gebruik het nieuwe systeem.
        speedCount = Input.GetAxisRaw("Horizontal");

        if(isGrounded)
        {
            transform.Translate(transform.right * speedCount * speed * Time.deltaTime);
        }

        else
        {
            playerRigidbody.AddForce(transform.right * speedCount * airSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        //gravity
        playerRigidbody.AddForce(-transform.up * gravity * Time.deltaTime);
        if(isGrounded == false)
        {
            gravity += gravityMultiplier;
        }

        else
        {
            gravity = 0;
        }

        //avoid double jump
        jumpResetCounter += Time.deltaTime;

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && GetComponent<WallJumping>().onWall == false && jumpResetCounter > jumpResetTime)
        {
            jumping = true;
        }

        playerAnimations.isJumping = jumping;
    }

    private void FixedUpdate()
    {
        
        if(jumping)
        {
            print("jump");
            jumpResetCounter = 0;
            playerRigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime);

            if (speedCount == 1)
            {
                //right
                transform.Translate(transform.right * jumpSideSpeed * Time.deltaTime);
            }

            else if (speedCount == -1)
            {
                //left
                transform.Translate(-transform.right * jumpSideSpeed * Time.deltaTime);
            }

            jumping = false;
        }
    }
}
