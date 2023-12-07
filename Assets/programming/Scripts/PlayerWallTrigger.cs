using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallTrigger : MonoBehaviour
{
    public bool isLeft;
    public bool isRight;

    public WallJumping wallJumping;
    public MovementPlayer movementPlayer;

    private float collidersInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground" && movementPlayer.isGrounded == false)
        {
            wallJumping.onWall = true;

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
        collidersInTrigger--;

        if (other.gameObject.tag == "Ground" && collidersInTrigger == 0)
        {
            wallJumping.onWall = false;

            wallJumping.onLeftWall = false;
            wallJumping.onRightWall = false;

            wallJumping.slideSpeed = 0;
            
        }
    }
}
