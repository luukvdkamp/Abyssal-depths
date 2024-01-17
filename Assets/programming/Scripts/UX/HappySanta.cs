using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappySanta : MonoBehaviour
{
    public AudioSource happySanta;

    private void OnTriggerEnter(Collider other)
    {
        happySanta.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        happySanta.Pause();
    }
}
