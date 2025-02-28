using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickup : MonoBehaviour
{
    public Bow bowToUpgrade;
    public GameObject[] upgradesToDestroy;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bowToUpgrade.chargeSpeedUpgrade++;

                for (int i = 0; i < upgradesToDestroy.Length; i++)
                {
                    Destroy(upgradesToDestroy[i]);
                }

            }
        }

    }
}
