using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public GameObject player;

    public MovementPlayer movementPlayer;
    public WallJumping wallJumping;
    public Health health;
    public Bow bow;
    public Gun gun;

    public Animator animator;

    public bool isJumping;
    private bool ableToLand;

    private float landingDelayCount;
    public float landingDelayDuration;

    public bool onRight;
    public bool onLeft;

    public bool onRope;

    public bool ropeUp;
    public bool ropeDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //walking
        float walkSpeed = Input.GetAxis("Horizontal");
        if (walkSpeed != 0 && movementPlayer.isGrounded)
        {
            animator.SetBool("Walking", true);
        }

        else
        {
            animator.SetBool("Walking", false);
        }


        // Rotate mouse aim
        if (gun.targetPosition.position.x > transform.position.x && onRope == false)
        {
            // Keep the existing X and Z rotation, only modify Y-axis rotation
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if(onRope == false)
        {
            // Keep the existing X and Z rotation, only modify Y-axis rotation
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

        //jumping
        if (isJumping)
        {
            animator.SetBool("Jumping", true);
        }

        //landing (delayed check)
        if (!movementPlayer.isGrounded)
        {
            landingDelayCount -= Time.deltaTime; // Decrease the timer
        }
        else
        {

            // Check for landing animation
            if (landingDelayCount <= 0f)
            {
                animator.SetBool("Landing", true);
            }
            else
            {
                animator.SetBool("Landing", false);
            }

            // The player is grounded, reset the timer
            landingDelayCount = landingDelayDuration;
        }

        // Reset the jumping animation if the player is grounded
        if (!isJumping && movementPlayer.isGrounded)
        {
            animator.SetBool("Jumping", false);
        }



        //bow aiming
        float angle = gun.angle;
        animator.SetFloat("AimAngle", angle);

        //rope
        if(onRope)
        {
            animator.SetBool("OnRope", true);
            if (onRight)
            {
                transform.localRotation = Quaternion.Euler(0, -90, 0);
            }

            else if (onLeft)
            {
                // Keep the existing X and Z rotation, only modify Y-axis rotation
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }

            if(ropeUp)
            {
                animator.SetBool("ropeUp", true);
                animator.SetBool("ropeDown", false);

                animator.speed = 1;
            }

            else if(ropeDown)
            {
                animator.SetBool("ropeDown", true);
                animator.SetBool("ropeUp", false);

                animator.speed = 1;
            }

            else if(ropeDown == false && ropeUp == false)
            {
                animator.speed = 0;
            }
        }

        else
        {
            animator.SetBool("OnRope", false);
            animator.SetBool("ropeUp", false);
            animator.SetBool("ropeDown", false);

            animator.speed = 1;
        }

    }
}
