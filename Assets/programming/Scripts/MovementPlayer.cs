using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 movement;
    public Rigidbody playerRigidbody;
    public bool isGrounded;
    public float speedCount;

    [Header("Speed values")]
    public float speed;
    public float airSpeed;
    public float jumpSpeed;
    public float jumpSideSpeed;

    /*
    public float velocityLimit;
    public float velocityLimiterMultiplier;
    */

    public float gravity;
    public float gravityMultiplier;

    private void Start()
    {
        
    }

    void Update()
    {
        //horizontal movement, gebruik het nieuwe systeem.
        speedCount = Input.GetAxisRaw("Horizontal");

        if(isGrounded)
        {
            transform.Translate(transform.right * speedCount * speed);
        }

        else
        {
            playerRigidbody.AddForce(transform.right * speedCount * airSpeed, ForceMode.Impulse);
        }

        //gravity
        playerRigidbody.AddForce(-transform.up * gravity);
        if(isGrounded == false)
        {
            gravity += gravityMultiplier;
        }

        else
        {
            gravity = 0;
        }
    }

    private void FixedUpdate()
    {
        //jump
        if (Input.GetKey(KeyCode.Space) && isGrounded && GetComponent<WallJumping>().onWall == false)
        {
            playerRigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime);

            if(speedCount == 1)
            {
                //right
                transform.Translate(transform.right * jumpSideSpeed * Time.deltaTime);
            }

            else if(speedCount == -1)
            {
                //left
                transform.Translate(-transform.right * jumpSideSpeed * Time.deltaTime);
            }
        }

        //limit velocity
        /*
        if (playerRigidbody.velocity.magnitude > velocityLimit)
        {
            playerRigidbody.velocity = playerRigidbody.velocity.normalized * velocityLimiterMultiplier;
        }
        */
    }
}
