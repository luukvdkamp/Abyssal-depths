using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickup : MonoBehaviour
{
    public Bow bowToUpgrade;
    public GameObject[] upgradesToDestroy;
    public int bowChargeUpgrade;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                bowToUpgrade.chargeSpeedUpgrade += bowChargeUpgrade;

                for (int i = 0; i < upgradesToDestroy.Length; i++)
                {
                    Destroy(upgradesToDestroy[i]);
                }

            }
        }

    }
}
