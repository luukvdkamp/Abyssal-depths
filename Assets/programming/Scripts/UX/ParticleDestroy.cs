using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public float timeBeforeDestroy;

    void Update()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}
