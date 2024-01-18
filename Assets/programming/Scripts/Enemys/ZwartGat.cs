using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZwartGat : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().gotHit = true;
            other.gameObject.GetComponent<Health>().damage = 100;
        }
    }
}
