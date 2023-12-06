using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public Transform barrelRotation;
    private Quaternion beginningBarrelRotation;

    public float bulletSpeed;
    public float bulletLifetime;
    public float bulletDamage;

    private void Start()
    {
        beginningBarrelRotation = barrelRotation.rotation;
        transform.rotation = beginningBarrelRotation;
    }

    private void Update()
    {
        // Move the bullet using Rigidbody velocity
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        // Destroy the bullet after a certain time
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().healthSlider.value -= bulletDamage;
            Destroy(gameObject);
        }
    }
}
