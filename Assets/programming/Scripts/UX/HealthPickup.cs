using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    public float hpGain;
    public Slider playerHP;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }
}
