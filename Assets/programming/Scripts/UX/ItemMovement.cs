using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float speed = 2.0f; // Adjustable speed
    public float movementRange = 1.0f; // Adjustable range of movement

    private float initialY;

    void Start()
    {
        // Store the initial Y position of the object
        initialY = transform.position.y;
    }

    void Update()
    {
        // Calculate the new Y position based on a sine wave with limited range
        float newY = initialY + Mathf.Sin(Time.time * speed) * movementRange;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
