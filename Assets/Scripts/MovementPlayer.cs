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
    public float jumpSpeed;
    public float jumpSideSpeed;

    public float velocityLimit;
    public float velocityLimiterMultiplier;

    public float gravity;
    public float gravityMultiplier;

    private void Start()
    {
        
    }

    void Update()
    {
        //horizontal movement
        speedCount = Input.GetAxis("Horizontal");

        //reset velocity when no input
        if(speedCount < 0.7f && speedCount > -0.7f)
        {
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        }

        playerRigidbody.AddForce(transform.right * speedCount * speed, ForceMode.Impulse);

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
                playerRigidbody.AddForce(transform.right * jumpSideSpeed * Time.deltaTime);
            }

            else if(speedCount == -1)
            {
                //left
                playerRigidbody.AddForce(-transform.right * jumpSideSpeed * Time.deltaTime);
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
