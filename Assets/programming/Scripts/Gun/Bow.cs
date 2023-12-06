using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform barrel;
    public GameObject bulletPrefab;

    public float chargeTime;
    public float maxChargeTime;
    public float minimumChargeTime;

    void Update()
    {

        if (Input.GetButtonUp("Fire1") && chargeTime > minimumChargeTime || chargeTime > maxChargeTime)
        {

            GameObject prefab = Instantiate(bulletPrefab, barrel.position, barrel.rotation);

            prefab.GetComponent<BowBullet>().chargeTime = chargeTime;

            chargeTime = 0;
         
        }

        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;

        }

        else
        {
            chargeTime = 0;
        }
    }
}
