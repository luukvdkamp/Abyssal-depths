using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundAmbience;
    public AudioSource metalDamage;
    public bool gotHit;

    void Update()
    {
        if(gotHit)
        {
            metalDamage.Play();
            gotHit = false;
        }
    }
}
