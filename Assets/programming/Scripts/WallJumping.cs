using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumping : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public PlayerAnimations playerAnimations;
    public MovementPlayer movementPlayer;

    public float maxSlideSpeed;
    public float speedIncrease;

    public float wallJumpingUpSpeed;
    public float wallJumpingSideSpeed;

    [Header("Don't edit")]
    public bool onLeftWall;
    public bool onRightWall;

    public bool onWall;
    public float slideSpeed = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onWall)
        {
            WallJump();
        }
    }

    private void FixedUpdate()
    {
        if (onWall)
        {

            transform.Translate(Vector3.down * slideSpeed * Time.fixedDeltaTime);

            slideSpeed += speedIncrease * Time.fixedDeltaTime;
        }

        slideSpeed = Mathf.Clamp(slideSpeed, 0, maxSlideSpeed);

        if(movementPlayer.isGrounded == true)
        {
            onWall = false;

            playerRigidbody.useGravity = true;

            onLeftWall = false;
            onRightWall = false;

            slideSpeed = 0;

            movementPlayer.enabled = true;
        }
    }

    void WallJump()
    {

        playerAnimations.wallJump = true;
        if (onLeftWall)
        {
            //onLeftWall
            playerRigidbody.AddForce(transform.right * wallJumpingSideSpeed * Time.fixedDeltaTime);
            playerRigidbody.AddForce(transform.up * wallJumpingUpSpeed * Time.fixedDeltaTime);

            onWall = false;
            onLeftWall = false;
            playerRigidbody.useGravity = true;

            slideSpeed = 0;

            movementPlayer.enabled = true;
        }

        else
        {
            //onRightWall
            playerRigidbody.AddForce(-transform.right * wallJumpingSideSpeed * Time.fixedDeltaTime);
            playerRigidbody.AddForce(transform.up * wallJumpingUpSpeed * Time.fixedDeltaTime);

            onWall = false;
            onRightWall = false;
            playerRigidbody.useGravity = true;

            slideSpeed = 0;

            movementPlayer.enabled = true;
        }

    }
}
