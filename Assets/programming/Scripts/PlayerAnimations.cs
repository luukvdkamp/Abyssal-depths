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
    public Crouching crouching;

    public Animator animator;
    public Transform playerForward;

    [Header("Jumping")]
    public bool isJumping;
    private float landingDelayCount;
    public float landingDelayDuration;

    [Header("Rope climbing")]
    public bool onRight;
    public bool onLeft;

    public bool onRope;

    public bool ropeUp;
    public bool ropeDown;

    [Header("Health")]
    public bool gameOver;
    public bool damagePlayer;

    [Header("wallJumping")]
    public bool wallJump;

    [Header("Crouching")]
    public float crouchInput;

    [Header("EdgeClimbing")]
    public bool edgeClimbing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WallSlidingAndJumping();
        Walking();
        Jumping();
        RopeClimbing();
        HealthPlayer();
        Crouching();
        EdgeClimbing();

        // Rotate mouse aim
        if (gun.targetPosition.position.x > transform.position.x && onRope == false && wallJumping.onWall == false && wallJump == false)
        {
            // Keep the existing X and Z rotation, only modify Y-axis rotation
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if(onRope == false && wallJumping.onWall == false && wallJump == false)
        {
            // Keep the existing X and Z rotation, only modify Y-axis rotation
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

   
        //bow aiming
        float angle = gun.angle;
        animator.SetFloat("AimAngle", angle);

    }

    void Crouching()
    {
        crouchInput = Input.GetAxisRaw("Horizontal");

        if(crouching.isCrouching)
        {
            animator.SetBool("Crouching", true);

            if(crouchInput == 0)
            {
                animator.speed = 0;
            }

            else
            {
                animator.speed = 1;
            }
        }

        else
        {
            animator.SetBool("Crouching", false);
        }
    }

    void Walking()
    {
        //walking
        float walkSpeed = Input.GetAxisRaw("Horizontal");
        if (walkSpeed != 0 && movementPlayer.isGrounded)
        {
            animator.SetBool("isWalking", true);
            if(walkSpeed > 0)
            {
                //right

                if(transform.localRotation == Quaternion.Euler(0, 90, 0))
                {
                    //forward
                    animator.SetFloat("walking", 1);
                }

                else if(transform.localRotation == Quaternion.Euler(0, -90, 0))
                {
                    //backwards
                    animator.SetFloat("walking", -1);
                }
            }

            else if (walkSpeed < 0)
            {
                //left

                if (transform.localRotation == Quaternion.Euler(0, 90, 0))
                {
                    //forward
                    animator.SetFloat("walking", -1);
                }

                else if (transform.localRotation == Quaternion.Euler(0, -90, 0))
                {
                    //backwards
                    animator.SetFloat("walking", 1);
                }
            }
        }

        else
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("walking", 0);
        }

    }

    void Jumping()
    {
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
    }

    void RopeClimbing()
    {
        //rope
        if (onRope)
        {
            animator.SetBool("OnRope", true);

            //HORIZONTAL
            if (onRight)
            {
                transform.localRotation = Quaternion.Euler(0, -90, 0);
            }

            else if (onLeft)
            {
                // Keep the existing X and Z rotation, only modify Y-axis rotation
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }

            else if (onRight == false && onLeft == false)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }




            //VERTICAL
            if (ropeUp)
            {
                animator.SetBool("ropeUp", true);
                animator.SetBool("ropeDown", false);

                animator.speed = 1;
            }

            else if (ropeDown)
            {
                animator.SetBool("ropeDown", true);
                animator.SetBool("ropeUp", false);

                animator.speed = 1;
            }

            else if (ropeDown == false && ropeUp == false)
            {
                animator.speed = 0;
            }
        }

        else if(wallJumping.onWall == false && crouching.isCrouching == false)
        {
            animator.SetBool("OnRope", false);
            animator.SetBool("ropeUp", false);
            animator.SetBool("ropeDown", false);

            animator.speed = 1;
        }
    }

    void HealthPlayer()
    {
        if(damagePlayer && gameOver == false)
        {
            animator.SetBool("Damage", true);

            StartCoroutine(TurnOffDamageBoolAfterDelay(0.5f));
        }

        else if(gameOver)
        {
            animator.SetBool("GameOver", true);
            gameOver = false;
        }


    }

    private IEnumerator TurnOffDamageBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetBool("Damage", false);
        damagePlayer = false;
    }

    void WallSlidingAndJumping()
    {
        if(wallJumping.onWall)
        {
            print("onWall");
            animator.SetBool("onWall", true);
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("WallJump"))
            {
                animator.speed = 0;
            }

            if (wallJumping.onLeftWall)
            {
                transform.localRotation = Quaternion.Euler(0, -90, 0);
                print("left");
            }

            else
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                print("right");
            }
        }

        else
        {
            animator.SetBool("onWall", false);
        }

        if(wallJump)
        {
            StartCoroutine(LetJumpAnimationPlay(0.5f));
            print("jump");
        }

    }
    private IEnumerator LetJumpAnimationPlay(float delay)
    {
        yield return new WaitForSeconds(delay);

        wallJump = false;
    }

    void EdgeClimbing()
    {
        if(edgeClimbing)
        {
            animator.SetBool("edgeClimbing", true);
        }

        else
        {
            animator.SetBool("edgeClimbing", false);
        }
    }
}
