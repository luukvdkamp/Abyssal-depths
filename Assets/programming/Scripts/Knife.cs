using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private GameObject bulletToParry;
    private GameObject enemy;

    private float bulletSpeed;
    private float bulletLifetime;
    private float bulletDamage;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            //take over data
            bulletToParry = other.gameObject;
            enemy = other.GetComponent<EnemyBullet>().enemyThatShotBullet.gameObject;

            //multiply
            other.GetComponent<EnemyBullet>().bulletSpeed *= 2;
            other.GetComponent<EnemyBullet>().lifetimeCount = 0;
            other.GetComponent<EnemyBullet>().bulletDamage *= 2;

            bulletToParry.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            bulletToParry.transform.LookAt(enemy.transform.position);
        }
    }

}
