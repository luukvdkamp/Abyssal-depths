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

    public float collidersInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            wallJumping.onWall = true;
            playerRigidbody.useGravity = false;
            movementPlayer.gravity = 0;
            movementPlayer.enabled = false;

            if(collidersInTrigger == 0)
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
            collidersInTrigger--;

            if(collidersInTrigger == 0)
            {
                wallJumping.onWall = false;
                playerRigidbody.useGravity = true;
    
                movementPlayer.enabled = true;

                wallJumping.onRightWall = false;
                wallJumping.onLeftWall = false;
            }
            
        }
    }
}
