using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGroundedCheck : MonoBehaviour
{
    public MovementPlayer movementPlayer;
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
            movementPlayer.isGrounded = false;
        }
    }
}
