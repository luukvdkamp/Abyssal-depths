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

    void Update()
    {
        float speedCount = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector3(speedCount * speed, rigidbody.velocity.y, rigidbody.velocity.z);

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && GetComponent<WallJumping>().onWall == false)
        {
            rigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime);
        }
    }
}
