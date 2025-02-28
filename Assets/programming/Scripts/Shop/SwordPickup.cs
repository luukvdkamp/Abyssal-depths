using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{

    public Knife swordToUpgrade;
    public GameObject[] upgradesToDestroy;
    public float parrySpeedUpgrade;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                swordToUpgrade.parryBulletSpeedMultiplier = swordToUpgrade.parryBulletSpeedMultiplier * parrySpeedUpgrade;

                for (int i = 0; i < upgradesToDestroy.Length; i++)
                {
                    Destroy(upgradesToDestroy[i]);
                }

            }
        }


    }

}
