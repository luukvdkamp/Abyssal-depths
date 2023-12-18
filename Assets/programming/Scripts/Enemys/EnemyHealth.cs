using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
