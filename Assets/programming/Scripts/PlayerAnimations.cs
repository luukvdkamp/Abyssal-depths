using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    public WallJumping wallJumping;
    public Health health;
    public Bow bow;
    public Gun gun;

    public Animator animator;

    private bool isJumping;
    private bool ableToLand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //walking
        float walkSpeed = Input.GetAxis("Horizontal");
        if(walkSpeed != 0 && movementPlayer.isGrounded)
        {
            animator.SetBool("Walking", true);
        }

        else
        {
            animator.SetBool("Walking", false);
        }

        //rotate mouse aim
        if(gun.targetPosition.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        //jumping
        if(movementPlayer.jumping)
        {
            animator.SetBool("Jumping", true);
            isJumping = true;

            animator.SetBool("Landing", false);
            
        }

        else
        {
            animator.SetBool("Jumping", false);
        }

        //landing
        if(isJumping && movementPlayer.isGrounded == false)
        {
            ableToLand = true;
        }

        if(ableToLand && movementPlayer.isGrounded)
        {
            animator.SetBool("Landing", true);
        }
    }
}
