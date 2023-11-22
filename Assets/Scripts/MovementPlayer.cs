using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 movement;
    public Rigidbody r;
    public bool isGrounded;

    [Header("Speed values")]
    public float speed;
    public float jumpSpeed;

    void Update()
    {
        float speedCount = Input.GetAxis("Horizontal");
        r.velocity = new Vector3(speedCount * speed, r.velocity.y, r.velocity.z);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            r.AddForce(transform.up * jumpSpeed * Time.deltaTime);
        }
    }
}
