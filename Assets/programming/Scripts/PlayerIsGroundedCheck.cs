using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGroundedCheck : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    public int objectsInTrigger;

    public void Update()
    {
        

        if (objectsInTrigger == 0)
        {
            movementPlayer.isGrounded = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            movementPlayer.isGrounded = true;
            if(objectsInTrigger == 0)
            {
                movementPlayer.playerRigidbody.velocity = new Vector3(0, 0, 0);
                
            }

            objectsInTrigger++;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ground" && movementPlayer.isGrounded == false)
        {
            movementPlayer.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            objectsInTrigger--;
        }
    }
}
