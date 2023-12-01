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
    }

    private void FixedUpdate()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && GetComponent<WallJumping>().onWall == false)
        {
            playerRigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime);

            if(speedCount == 1)
            {
                //right
                playerRigidbody.AddForce(transform.right * jumpSideSpeed * Time.deltaTime, ForceMode.Impulse);
            }

            else if(speedCount == -1)
            {
                //left
                playerRigidbody.AddForce(-transform.right * jumpSideSpeed * Time.deltaTime, ForceMode.Impulse);
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
