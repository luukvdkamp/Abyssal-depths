using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    public Transform barrel;
    public GameObject bulletPrefab;
    public Slider rangeSlider;

    public float chargeTime;
    public float maxChargeTime;
    public float minimumChargeTime;

    void Update()
    {

        rangeSlider.value = chargeTime;

        if (Input.GetButtonUp("Fire1") && chargeTime > minimumChargeTime || chargeTime > maxChargeTime)
        {

            GameObject prefab = Instantiate(bulletPrefab, barrel.position, barrel.rotation);

            prefab.GetComponent<BowBullet>().chargeTime = chargeTime;

            chargeTime = 0;
         
        }

        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;
            rangeSlider.gameObject.SetActive(true);

        }

        else
        {
            chargeTime = 0;
            rangeSlider.gameObject.SetActive(false);

        }
    }
}
