using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    public WallJumping wallJumping;
    public Health health;
    public Bow bow;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float walkSpeed = Input.GetAxis("Horizontal");
        if(walkSpeed != 0 && movementPlayer.isGrounded)
        {
            animator.SetBool("Walking", true);
            animator.speed = walkSpeed;
        }

        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
