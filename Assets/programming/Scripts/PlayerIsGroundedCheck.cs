using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGroundedCheck : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    public int objectsInTrigger;
    private int groundLayerMask;

    public void Start()
    {
        groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
    }

    public void Update()
    {
        

        if (objectsInTrigger == 0)
        {
            movementPlayer.isGrounded = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((groundLayerMask & (1 << other.gameObject.layer)) != 0)
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
        if ((groundLayerMask & (1 << other.gameObject.layer)) != 0 && !movementPlayer.isGrounded)
        {
            movementPlayer.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((groundLayerMask & (1 << other.gameObject.layer)) != 0)
        {
            objectsInTrigger--;
        }
    }
}
