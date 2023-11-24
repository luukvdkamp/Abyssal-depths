using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public bool onRope;
    private GameObject player;

    public Transform rightPosition;
    public Transform leftPosition;
    public Transform endOfRopePosition;

    public float verticalSpeed;
    public float upJumpSpeed;
    public float sideSpeed;

    public bool resetJump;
    private float resetJumpCounter;
    public float maxResetJump;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && resetJump == false)
        {
            onRope = true;
            player = other.gameObject;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {
        if(onRope)
        {
            player.GetComponent<MovementPlayer>().enabled = false;

            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");


            if(horizontalMovement > 0.2f)
            {
                //right
                player.transform.position = new Vector3(rightPosition.position.x, player.transform.position.y, player.transform.position.z);

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    resetJump = true;
                    player.GetComponent<Rigidbody>().AddForce(transform.right * sideSpeed * Time.deltaTime);

                }
            }

            else if(horizontalMovement < -0.2f)
            {
                //left
                player.transform.position = new Vector3(leftPosition.position.x, player.transform.position.y, player.transform.position.z);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    resetJump = true;
                    player.GetComponent<Rigidbody>().AddForce(-transform.right * sideSpeed * Time.deltaTime);

                }
            }

            else if(horizontalMovement == 0)
            {
                //middle
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);

            }




            if(verticalMovement > 0.2f)
            {
                //up
                player.transform.Translate(transform.up * verticalSpeed * Time.deltaTime);
            }

            else if(verticalMovement < -0.2f)
            {
                //down
                player.transform.Translate(-transform.up * verticalSpeed * Time.deltaTime);
            }

            //if player slide off rope
            if(player.transform.position.y < endOfRopePosition.position.y)
            {
                resetJump = true;
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
