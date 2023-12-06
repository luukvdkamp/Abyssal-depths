using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform enemyThatShotBullet; // for parry
    public Transform barrelRotation;
    private Quaternion beginningBarrelRotation;

    public float bulletSpeed;

    public float bulletLifetime;
    public float lifetimeCount;

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
        lifetimeCount += Time.deltaTime;
        if(lifetimeCount > bulletLifetime)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().healthSlider.value -= bulletDamage;
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
