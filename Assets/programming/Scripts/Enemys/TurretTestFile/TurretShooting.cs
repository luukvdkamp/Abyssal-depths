using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public Transform playerPosition;
    public Transform turretRaycastPosition;
    public Gun gunAimCode;

    public float fireRate;
    private float fireCount;
    public GameObject bullet;
    public Transform barrel;

    public AudioSource gunShot;

    public EnemyHealth turretHealth;

    [HideInInspector]
    public bool aiming;

    [HideInInspector]
    public float beginHealth;

    private void Start()
    {
        beginHealth = turretHealth.health;
    }

    private void Update()
    {
        barrel.LookAt(playerPosition);
        Vector3 rayDirection = playerPosition.position - barrel.transform.position;

        Physics.Raycast(barrel.transform.position, rayDirection, out RaycastHit hit, 1000);
        if (hit.transform.gameObject.tag == "Player")
        {
            aiming = true;

            Debug.DrawRay(barrel.transform.position, rayDirection, Color.red);

            fireCount += Time.deltaTime;
            if (fireCount > fireRate)
            {
                GameObject prefab = Instantiate(bullet, barrel.position, barrel.rotation);
                prefab.GetComponent<EnemyBullet>().barrelRotation = barrel;
                prefab.GetComponent<EnemyBullet>().enemyThatShotBullet = transform;
                fireCount = 0;

                gunShot.Play();
            }
        }

        else
        {

            fireCount = 0;

            Debug.DrawRay(barrel.transform.position, rayDirection, Color.green);
            aiming = false;

        }

    }
}
