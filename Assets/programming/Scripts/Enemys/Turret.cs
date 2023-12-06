using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform playerPosition;
    public Transform turretRaycastPosition;
    public Gun gunAimCode;

    public float fireRate;
    private float fireCount;
    public GameObject bullet;
    public Transform barrel;

    private void Update()
    {
        // Calculate the direction from barrel to player
        Vector3 rayDirection = playerPosition.position - barrel.transform.position;

        // Perform the raycast
        Physics.Raycast(barrel.transform.position, rayDirection, out RaycastHit hit, 1000);
        if (hit.transform.gameObject.tag == "Player")
        {
            // Draw the ray in the Scene view
            Debug.DrawRay(barrel.transform.position, rayDirection, Color.red);

            // Handle the hit object if needed
            // For example, you can access hit.collider.gameObject to get the GameObject hit
            gunAimCode.enabled = true;

            fireCount += Time.deltaTime;
            if(fireCount > fireRate)
            {
                GameObject prefab = Instantiate(bullet, barrel.position, barrel.rotation);
                prefab.GetComponent<TurretBullet>().barrelRotation = barrel;
                fireCount = 0;
            }
        }
        else
        {

            fireCount = 0;
            // If the ray doesn't hit anything, draw the full ray
            gunAimCode.enabled = false;
            Debug.DrawRay(barrel.transform.position, rayDirection, Color.green);
            
        }
    }
}
