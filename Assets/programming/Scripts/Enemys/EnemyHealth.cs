using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public SoundManager soundManager;

    private float previousValue;

    private void Start()
    {
       
        previousValue = health;
    }

    void Update()
    {
        
        if (health != previousValue)
        {
            soundManager.gotHit = true;

            previousValue = health;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
