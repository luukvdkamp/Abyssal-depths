using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public Animator animator;

    public float jumpHeight;
    public float jumpSideSpeed;

    public float jumpTime;
    private float jumpCounter;

    public int maxAmountOfSideJumps;
    private int sideJumpCounter;

    private bool goingRight;
    private bool goingLeft;

    public float jumpDelay; //delay because the animation of the enemy begins a bit later 

    private void Start()
    {
        goingRight = true;
    }

    void Update()
    {
        //check when the enemy is going to jump
        if(jumpCounter >= jumpTime)
        {
            Jump();
        }

        else
        {
            jumpCounter += Time.deltaTime;
        }


        //check how many times the enemy jump one way (right or left)
        if(sideJumpCounter >= maxAmountOfSideJumps)
        {
            if(goingRight)
            {
                goingRight = false;
                goingLeft = true;
            }

            else if(goingLeft)
            {
                goingLeft = false;
                goingRight = true;
            }

            sideJumpCounter = 0;
        }
    }

    void Jump()
    {
        animator.Play("Jumping", 0, 0f);

        // Delay using StartCoroutine
        StartCoroutine(DelayedJump());
    }

    IEnumerator DelayedJump()
    {
        // Wait for 1 second (adjust the delay time as needed)
        yield return new WaitForSeconds(jumpDelay);

        // Continue with the rest of the code after the delay
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

        if (goingRight)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * jumpSideSpeed, ForceMode.Impulse);
            print("jumpingSideways");
        }
        else if (goingLeft)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * jumpSideSpeed, ForceMode.Impulse);
            print("jumpingSideways");
        }

        jumpCounter = 0;
        sideJumpCounter++;
    }
}
