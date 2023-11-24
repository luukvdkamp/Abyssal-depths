using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumping : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public float maxSlideSpeed;
    public float speedIncrease;

    public float wallJumpingUpSpeed;
    public float wallJumpingSideSpeed;

    [Header("Don't edit")]
    public bool onLeftWall;
    public bool onRightWall;

    public bool onWall;
    public float slideSpeed = 0;


    private void FixedUpdate()
    {
        if(onWall)
        {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, -slideSpeed, playerRigidbody.velocity.z);

            slideSpeed += speedIncrease;

            if(Input.GetKey(KeyCode.Space))
            {
                WallJump();
            }
        }

        slideSpeed = Mathf.Clamp(slideSpeed, 0, maxSlideSpeed);
    }

    void WallJump()
    {
        if (onLeftWall)
        {
            //onLeftWall
            playerRigidbody.AddForce(transform.right * wallJumpingSideSpeed * Time.deltaTime);
            playerRigidbody.AddForce(transform.up * wallJumpingUpSpeed * Time.deltaTime);

            onWall = false;
            onLeftWall = false;

            slideSpeed = 0;
        }

        else
        {
            //onRightWall
            playerRigidbody.AddForce(-transform.right * wallJumpingSideSpeed * Time.deltaTime);
            playerRigidbody.AddForce(transform.up * wallJumpingUpSpeed * Time.deltaTime);

            onWall = false;
            onRightWall = false;

            slideSpeed = 0;
        }
    }
}
