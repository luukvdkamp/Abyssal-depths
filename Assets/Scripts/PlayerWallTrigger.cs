using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallTrigger : MonoBehaviour
{
    public bool isLeft;
    public bool isRight;

    public WallJumping wallJumping;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            wallJumping.onWall = true;

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
        if (other.gameObject.tag == "Ground")
        {
            wallJumping.onWall = false;

            wallJumping.onLeftWall = false;
            wallJumping.onRightWall = false;

            wallJumping.slideSpeed = 0;
            
        }
    }
}
