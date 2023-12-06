using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBullet : MonoBehaviour
{


    public float lowerForce;

    public float speed;
    public float chargeTime;
    public float lifeTime;
    private float amountofGravity;
    public float gravityStrength;


    private void Update()
    {
        float bulletSpeed = chargeTime * speed * lowerForce;

        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        GetComponent<Rigidbody>().AddForce(Vector3.down * amountofGravity * Time.deltaTime);

        lowerForce -= Time.deltaTime;
        amountofGravity += Time.deltaTime * gravityStrength;

        Destroy(gameObject, lifeTime);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(GetComponent<BoxCollider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
}
