using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallTrigger : MonoBehaviour
{
    public bool isLeft;
    public bool isRight;

    public WallJumping wallJumping;
    public MovementPlayer movementPlayer;
    public Rigidbody playerRigidbody;
    public EdgeClimb edgeClimb;
    public PlayerAnimations playerAnimations;

    public float collidersInTrigger;
    public Transform playerPosition;

    public float timeBeforeAllowColliderRemoval;
    private float colliderRemovalCounter;

    private bool exitTrigger;

    public void Update()
    {
        colliderRemovalCounter += Time.deltaTime;

        if (exitTrigger && colliderRemovalCounter > timeBeforeAllowColliderRemoval) 
        {
            exitTrigger = false;
            collidersInTrigger = 0;
            colliderRemovalCounter = 0;

            if (collidersInTrigger == 0)
            {
                wallJumping.onWall = false;
                playerRigidbody.useGravity = true;

                movementPlayer.enabled = true;

                wallJumping.onRightWall = false;
                wallJumping.onLeftWall = false;
            }

            playerAnimations.animator.speed = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall" && movementPlayer.isGrounded == false)
        {
            exitTrigger = false;
            wallJumping.onWall = true;
            playerRigidbody.useGravity = false;
            movementPlayer.gravity = 0;
            movementPlayer.enabled = false;

            if (collidersInTrigger == 0)
            {
                playerRigidbody.velocity = new Vector3(0, 0, 0);
            }

            collidersInTrigger++;

            if (isLeft)
            {
                //wall on left side player
                wallJumping.onLeftWall = true;
            }

            else
            {
                //wall on right side player
                wallJumping.onRightWall = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Wall")
        {
            exitTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
         
        // edge climbing
        if (other.gameObject.tag == "Ground" && Input.GetKey(KeyCode.Space) && wallJumping.onWall == false)
        {
            if (other.gameObject.tag != "Slope")
            {
                if (playerPosition.position.x < other.transform.position.x)
                {
                    edgeClimb.rightWallClimbing = true;
                }
                else
                {
                    edgeClimb.rightWallClimbing = false;
                }

                edgeClimb.isEdgeClimbing = true;

                edgeClimb.edgeClimbPosition = other.transform.GetChild(0);
                print("working");
            }
        }

        */

    }
}
