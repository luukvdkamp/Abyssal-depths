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
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Slope")
        {
            movementPlayer.isGrounded = true;
            if (objectsInTrigger == 0)
            {
                movementPlayer.playerRigidbody.velocity = Vector3.zero;
            }

            objectsInTrigger++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Slope" && !movementPlayer.isGrounded)
        {
            movementPlayer.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Slope")
        {
            objectsInTrigger--;
        }
    }
}
