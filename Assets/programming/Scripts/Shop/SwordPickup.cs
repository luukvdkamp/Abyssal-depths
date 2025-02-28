using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{

    public Knife swordToUpgrade;

    public GameObject[] upgradesToDestroy;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                swordToUpgrade.parryBulletSpeedMultiplier = swordToUpgrade.parryBulletSpeedMultiplier * 2;

                for (int i = 0; i < upgradesToDestroy.Length; i++)
                {
                    Destroy(upgradesToDestroy[i]);
                }

            }
        }


    }

}
