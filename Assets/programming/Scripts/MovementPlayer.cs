using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 movement;
    public Rigidbody playerRigidbody;
    public bool isGrounded;
    public float speedCount;
    public bool jumping;

    [Header("Speed values")]
    public float speed;
    public float airSpeed;

    public float jumpSpeed;
    public float jumpSideSpeed;

    public float jumpResetTime;
    private float jumpResetCounter;

    public float gravity;
    public float gravityMultiplier;

    [Header("Player Animation")]
    public PlayerAnimations playerAnimations;
    public GameObject playerModel;



    private void Start()
    {
        
    }

    void Update()
    {
        //horizontal movement, gebruik het nieuwe systeem.
        speedCount = Input.GetAxisRaw("Horizontal");

        if(isGrounded)
        {
            transform.Translate(transform.right * speedCount * speed * Time.deltaTime);
        }

        else
        {
            playerRigidbody.AddForce(transform.right * speedCount * airSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        //gravity
        playerRigidbody.AddForce(-Vector3.up * gravity * Time.deltaTime);
        if(isGrounded == false)
        {
            gravity += gravityMultiplier;
        }

        else
        {
            gravity = 0;
        }

        //avoid double jump
        jumpResetCounter += Time.deltaTime;

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && GetComponent<WallJumping>().onWall == false && jumpResetCounter > jumpResetTime)
        {
            jumping = true;
        }

        playerAnimations.isJumping = jumping;


        // Define the layer mask to include only the "Ground" layer
        int groundLayerMask = 1 << LayerMask.NameToLayer("Ground");


        //slope rotation

        // Cast a ray downward to detect the slope angle, using the groundLayerMask
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1, groundLayerMask))
        {
            
            // Your existing code to calculate slope angle and rotate the player
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up) * Mathf.Sign(hit.normal.x);
            //float clampedRotation = Mathf.Clamp(slopeAngle, -45, 45);
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, -slopeAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        else
        {
            Vector3 targetEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    private void FixedUpdate()
    {
        
        if(jumping)
        {
            print("jump");

            jumpResetCounter = 0;
            playerRigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime);

            if (speedCount == 1)
            {
                //right
                transform.Translate(transform.right * jumpSideSpeed * Time.deltaTime);
            }

            else if (speedCount == -1)
            {
                //left
                transform.Translate(-transform.right * jumpSideSpeed * Time.deltaTime);
            }
            jumping = false;
        }
    }
}
