using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public Animator animator;

    public float jumpHeight;
    public float jumpSideSpeed;

    public float damage;
    private float damageCounter;
    public float damageResetTime;

    public float jumpTime;
    private float jumpCounter;

    public int maxAmountOfSideJumps;
    private int sideJumpCounter;

    private bool goingRight;
    private bool goingLeft;

    public float jumpDelay; //delay because the animation of the enemy begins a bit later 

    private bool isGrounded;
    public int objectsInTrigger;

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


        //damage reset
        damageCounter += Time.deltaTime;

        if (objectsInTrigger == 0)
        {
            isGrounded = false;

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
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight * Time.deltaTime);

        if (goingRight)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * jumpSideSpeed * Time.deltaTime);
            print("jumpingSideways");
        }
        else if (goingLeft)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * jumpSideSpeed * Time.deltaTime);
            print("jumpingSideways");
        }

        jumpCounter = 0;
        sideJumpCounter++;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && damageCounter > damageResetTime)
        {
            other.gameObject.GetComponent<Health>().gotHit = true;
            other.gameObject.GetComponent<Health>().damage = damage;

            damageCounter = 0;
        }
    }

    //is grounded check
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;

            objectsInTrigger++;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            objectsInTrigger--;
        }
    }
}
