using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public bool onRope;
    private GameObject player;

    public Transform rightPosition;
    public Transform leftPosition;

    public float verticalSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            onRope = true;
            player = other.gameObject;
            player.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onRope = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<MovementPlayer>().enabled = true;
        }
    }

    private void Update()
    {
        if(onRope)
        {
            player.GetComponent<MovementPlayer>().enabled = false;

            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");


            if(horizontalMovement > 0.7f)
            {
                //right
                player.transform.position = new Vector3(rightPosition.position.x, player.transform.position.y, player.transform.position.z);
            }

            else if(horizontalMovement < -0.7f)
            {
                //left
                player.transform.position = new Vector3(leftPosition.position.x, player.transform.position.y, player.transform.position.z);
            }

            else if(horizontalMovement == 0)
            {
                //middle
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
            }




            if(verticalMovement > 0.7f)
            {
                //up
                player.transform.Translate(transform.up * verticalSpeed * Time.deltaTime);
            }

            else if(verticalMovement < -0.7f)
            {
                //down
                player.transform.Translate(-transform.up * verticalSpeed * Time.deltaTime);
            }
        }
    }
}
