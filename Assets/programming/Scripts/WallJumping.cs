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

    public float waitTimeBeforeJump;
    private float waitBeforeJumpCounter;

    [Header("Don't edit")]
    public bool onLeftWall;
    public bool onRightWall;

    public bool onWall;
    public float slideSpeed = 0;

    private void Update()
    {
        if (onWall)
        {
            transform.Translate(Vector3.down * slideSpeed * Time.deltaTime);

            slideSpeed += speedIncrease;
            waitBeforeJumpCounter += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && waitBeforeJumpCounter > waitTimeBeforeJump)
            {
                WallJump();
                waitBeforeJumpCounter = 0;
            }
        }

        else
        {
            waitBeforeJumpCounter = waitTimeBeforeJump;
        }
    }


    private void FixedUpdate()
    {

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
        StartCoroutine(WallJumpCoroutine());
    }

    private IEnumerator WallJumpCoroutine()
    {
        playerAnimations.wallJump = true;

        if (onLeftWall)
        {
            playerRigidbody.AddForce(transform.right * wallJumpingSideSpeed * Time.fixedDeltaTime);
            playerRigidbody.AddForce(transform.up * wallJumpingUpSpeed * Time.fixedDeltaTime);

        }
        else
        {
            playerRigidbody.AddForce(-transform.right * wallJumpingSideSpeed * Time.fixedDeltaTime);
            playerRigidbody.AddForce(transform.up * wallJumpingUpSpeed * Time.fixedDeltaTime);

        }

        print("jump");

        yield return new WaitForSeconds(0.5f); 

        if (onLeftWall)
            onLeftWall = false;
        else
            onRightWall = false;

        onWall = false;
        playerRigidbody.useGravity = true;
        slideSpeed = 0;
        movementPlayer.enabled = true;
        playerAnimations.wallJump = false; 
    }

}
