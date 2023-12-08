using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public bool onRope;
    public GameObject player;

    public Transform rightPosition;
    public Transform leftPosition;
    public Transform endOfRopeUpPosition;
    public Transform endOfRopeDownPosition;

    public float verticalSpeed;
    public float upJumpSpeed;
    public float sideSpeed;

    public bool resetJump;
    private float resetJumpCounter;
    public float maxResetJump;
    public float verticalMovement;

    public PlayerAnimations playerAnimations;

    private void Update()
    {
        //check if holding up
        if (resetJump == false && verticalMovement > 0.2f)
        {
            //check if player right position horizontal
            if(player.transform.position.x < rightPosition.position.x && player.transform.position.x > leftPosition.position.x)
            {
                if (player.transform.position.y < endOfRopeUpPosition.position.y && player.transform.position.y > endOfRopeDownPosition.position.y)
                {
                    onRope = true;
                    player.GetComponent<Rigidbody>().useGravity = false;
                    player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                }
            }
            
        }

        verticalMovement = Input.GetAxisRaw("Vertical");

        if (onRope)
        {
            playerAnimations.onRope = true;

            player.GetComponent<MovementPlayer>().enabled = false;

            float horizontalMovement = Input.GetAxisRaw("Horizontal");


            if(horizontalMovement > 0.2f)
            {
                //right
                player.transform.position = new Vector3(rightPosition.position.x, player.transform.position.y, player.transform.position.z);

                playerAnimations.onRight = true;
                playerAnimations.onLeft = false;

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    resetJump = true;
                    player.GetComponent<Rigidbody>().AddForce(transform.right * sideSpeed * Time.deltaTime);
                    player.GetComponent<Rigidbody>().AddForce(transform.up * upJumpSpeed * Time.deltaTime);
                    playerAnimations.onRope = false;
                    playerAnimations.ropeUp = false;
                    playerAnimations.ropeDown = false;
                }
            }

            else if(horizontalMovement < -0.2f)
            {
                //left
                player.transform.position = new Vector3(leftPosition.position.x, player.transform.position.y, player.transform.position.z);

                playerAnimations.onRight = false;
                playerAnimations.onLeft = true;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    resetJump = true;
                    player.GetComponent<Rigidbody>().AddForce(-transform.right * sideSpeed * Time.deltaTime);
                    player.GetComponent<Rigidbody>().AddForce(transform.up * upJumpSpeed * Time.deltaTime);
                    playerAnimations.onRope = false;
                    playerAnimations.ropeUp = false;
                    playerAnimations.ropeDown = false;
                }
            }

            else if(horizontalMovement == 0)
            {
                //middle
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);

                playerAnimations.onRight = false;
                playerAnimations.onLeft = false;

            }




            if(verticalMovement > 0.2f)
            {
                //up
                player.transform.Translate(transform.up * verticalSpeed * Time.deltaTime);

                playerAnimations.ropeUp = true;
                playerAnimations.ropeDown = false;
            }

            else if(verticalMovement < -0.2f)
            {
                //down
                player.transform.Translate(-transform.up * verticalSpeed * Time.deltaTime);

                playerAnimations.ropeUp = false;
                playerAnimations.ropeDown = true;
            }

            else if(verticalMovement == 0)
            {
                playerAnimations.ropeUp = false;
                playerAnimations.ropeDown = false;
            }

            //if player slide off rope
            if(player.transform.position.y < endOfRopeDownPosition.position.y && verticalMovement < -0.2f)
            {
                resetJump = true;
                playerAnimations.onRope = false;
                playerAnimations.ropeUp = false;
                playerAnimations.ropeDown = false;
            }
        }

        

        //making sure the player does not activate trigger after jumping off rope
        if(resetJump)
        {
            onRope = false;
            resetJumpCounter += Time.deltaTime;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<MovementPlayer>().enabled = true;

            if (resetJumpCounter > maxResetJump)
            {
                resetJump = false;
                resetJumpCounter = 0;
           
            }

        }
    }
}
