using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 movement;
    public Rigidbody rigidbody;
    public bool isGrounded;

    [Header("Speed values")]
    public float speed;
    public float jumpSpeed;

    public float velocityLmit;
    public float velocityLimiterMultiplier;

    public float dragWhenStanding;
    private float dragWhenWalking;

    private void Start()
    {
        dragWhenWalking = rigidbody.drag;
    }

    void Update()
    {
        float speedCount = Input.GetAxis("Horizontal");
        if(speedCount < 0.7f && speedCount > -0.7f)
        {
            rigidbody.drag = dragWhenStanding;
        }

        else
        {
            rigidbody.drag = dragWhenWalking;
        }

        rigidbody.AddForce(transform.right * speedCount * speed, ForceMode.Impulse);

    }

    private void FixedUpdate()
    {
        //jump
        if (Input.GetKey(KeyCode.Space) && isGrounded && GetComponent<WallJumping>().onWall == false)
        {
            rigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime);
        }

        //limit velocity
        if (rigidbody.velocity.magnitude > velocityLmit)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * velocityLimiterMultiplier;
        }
    }
}
