using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public Transform[] checkpoints;
    public float flySpeed;
    public float dashSpeed;
    public float returnSpeed;
    public float attackDistance;
    public Transform player;
    public Animator animator;

    private int currentCheckpointIndex;
    private bool isStunned;
    private float dashTimeOut;

    private void Start()
    {
        currentCheckpointIndex = 0;
        isStunned = false;
    }

    private void Update()
    {
        dashTimeOut += Time.deltaTime;

        if (!isStunned)
        {
            FlyInCircles();

            animator.SetBool("isDashing", false);

            // Check distance to the player and initiate dash if within range
            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);
                if (distanceToPlayer < attackDistance && dashTimeOut > 2)
                {
                    StartCoroutine(DashToPlayer(player.position));
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collided with the ground or a wall
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            StartCoroutine(ReturnToNextCheckpoint());
        }
    }

    private void FlyInCircles()
    {
        // Move towards the current checkpoint
        Vector3 targetPosition = checkpoints[currentCheckpointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, flySpeed * Time.deltaTime);

        // Look at the checkpoint
        transform.LookAt(targetPosition);

        // Check if the enemy has reached the current checkpoint
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Move to the next checkpoint
            currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Length;
        }
    }

    private IEnumerator DashToPlayer(Vector3 playerPosition)
    {
        isStunned = true;

        animator.SetBool("isDashing", true);

        // Save the current position before dashing
        Vector3 startPosition = transform.position;

        // Calculate the direction towards the player
        Vector3 direction = Vector3.Normalize(playerPosition - startPosition);

        // Dash towards the player's position
        float elapsedTime = 0f;
        while (elapsedTime < Vector3.Distance(transform.position, playerPosition) / dashSpeed)
        {
            transform.position = Vector3.Lerp(startPosition, startPosition + direction * attackDistance, elapsedTime / (Vector3.Distance(transform.position, playerPosition) / dashSpeed));
            transform.LookAt(playerPosition); // Look at the player while dashing
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset isStunned and return to the next checkpoint
        isStunned = false;
        StartCoroutine(ReturnToNextCheckpoint());
        dashTimeOut = 0;
    }

    private IEnumerator ReturnToNextCheckpoint()
    {
        isStunned = true;

        Vector3 targetPosition = checkpoints[currentCheckpointIndex].position;
        while (Vector3.Distance(transform.position, targetPosition) < 0.1)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, returnSpeed);
            transform.LookAt(targetPosition); // Look at the next checkpoint while returning
            yield return null;
        }

        // Reset isStunned
        isStunned = false;
    }
}
