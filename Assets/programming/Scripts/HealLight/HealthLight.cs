using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLight : MonoBehaviour
{
    public GameObject player;
    public Slider healthSlider;
    public float healthGainSpeed;
    public float healingRange;

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < healingRange)
        {
            healthSlider.value += healthGainSpeed;
        }
    }
}
