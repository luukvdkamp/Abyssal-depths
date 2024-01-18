using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    private float playerNormalSpeed;
    public MovementPlayer movementPlayer;
    public float crouchSpeed;

    public bool isCrouching;

    private void Start()
    {
        playerNormalSpeed = movementPlayer.speed;   
    }

    public void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift) && movementPlayer.isGrounded)
        {
            isCrouching = true;
            movementPlayer.speed = crouchSpeed;
            GetComponent<CapsuleCollider>().height = 1;
        }

        else
        {
            movementPlayer.speed = playerNormalSpeed;
            isCrouching = false;
            GetComponent<CapsuleCollider>().height = 1.56f;
        }
    }
}
