using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceEnemy : MonoBehaviour
{
    private GameObject player;

    public float idleSpeed;
    public float attackSpeed;

    public bool movingRight;
    public bool movingLeft;

    public float distanceFromPlayer;
    private bool playerInVision;

    public Transform maxRightDistance;
    public Transform maxLeftDistance;
    public Transform maxUpDistance;

    public float idleTurnSpeed;
    private float idleTurnCount;
    public int amountOfIdleTurns;
    private int amountOfTurnCount;

    public float bulletResetTime;
    private float bulletResetCounter;
    public GameObject bulletPrefab;
    public Transform barrel;


    public Animator animator;

    [Header("states")]
    public bool idleState;
    public bool attackState;
    public bool searchState;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInVision = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInVision = false;
        }
    }

    private void Update()
    {
        
        if(idleState)
        {
            //movement
            if(movingRight)
            {
                transform.Translate(Vector3.right * idleSpeed * Time.deltaTime, Space.World);
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                if (Vector3.Distance(maxRightDistance.position, transform.position) < 1)
                {
                    movingRight = false;
                    movingLeft = true;
                }
            }

            else if(movingLeft)
            {
                transform.Translate(-Vector3.right * idleSpeed * Time.deltaTime, Space.World);
                transform.localRotation = Quaternion.Euler(0, -90, 0);
                if (Vector3.Distance(maxLeftDistance.position, transform.position) < 1)
                {
                    movingLeft = false;
                    movingRight = true;
                }
            }

            //spotting player
            if(playerInVision)
            {
                if(player.transform.position.x < maxRightDistance.position.x && player.transform.position.x > maxLeftDistance.position.x) //horizontal
                {
                    if(player.transform.position.y < maxUpDistance.position.y) //vertical
                    {
                        idleState = false;
                        attackState = true;
                    }
                }
            }


            animator.SetBool("isIdle", true);
            animator.SetBool("isSearching", false);
        }

        else if(attackState)
        {
            //movement
            if(Vector3.Distance(player.transform.position, transform.position) > distanceFromPlayer)
            {
                if (player.transform.position.x > transform.position.x && transform.position.x < maxRightDistance.position.x)
                {
                    transform.Translate(Vector3.right * attackSpeed * Time.deltaTime, Space.World);
                    transform.localRotation = Quaternion.Euler(0, 90, 0);
                    movingRight = true;
                }

                else if (player.transform.position.x < transform.position.x && transform.position.x > maxLeftDistance.position.x)
                {
                    transform.Translate(-Vector3.right * attackSpeed * Time.deltaTime, Space.World);
                    transform.localRotation = Quaternion.Euler(0, -90, 0);
                    movingLeft = true;
                }
            }

            if(playerInVision == false)
            {
                attackState = false;
                searchState = true;
            }

            //schooting
            bulletResetCounter += Time.deltaTime;
            if(bulletResetCounter > bulletResetTime)
            {
                bulletResetCounter = 0;
                GameObject prefab = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
                barrel.LookAt(player.transform.position);
                prefab.GetComponent<EnemyBullet>().bulletSpeed = 17;
                prefab.GetComponent<EnemyBullet>().barrelRotation = barrel;
                prefab.GetComponent<EnemyBullet>().enemyThatShotBullet = transform;
            }


            animator.SetBool("isIdle", false);
            animator.SetBool("isSearching", false);
            animator.SetBool("isAttacking", true);
        }

        else if(searchState)
        {
            idleTurnCount += Time.deltaTime;
            if (idleTurnCount > idleTurnSpeed)
            {
                idleTurnCount = 0;
                amountOfTurnCount++;

                if (movingRight)
                {
                    transform.localRotation = Quaternion.Euler(0, -90, 0);
                    movingRight = false;
                    movingLeft = true;
                }

                else if (movingLeft)
                {
                    transform.localRotation = Quaternion.Euler(0, 90, 0);
                    movingLeft = false;
                    movingRight = true;
                }
            }

            if(playerInVision)
            {
                idleTurnCount = 0;
                amountOfTurnCount = 0;
                searchState = false;
                attackState = true;
            }
            
            if(amountOfTurnCount == amountOfIdleTurns)
            {
                searchState = false;
                idleState = true;
                amountOfTurnCount = 0;
            }

            animator.SetBool("isAttacking", false);
            animator.SetBool("isSearching", true);
        }
    }
}
