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
        GetComponent<Rigidbody>().AddForce(transform.forward * chargeTime * speed * lowerForce * Time.deltaTime, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(Vector3.down * amountofGravity * Time.deltaTime);

        lowerForce -= Time.deltaTime;
        amountofGravity += Time.deltaTime * gravityStrength;

        Destroy(gameObject, lifeTime);
    }
}
