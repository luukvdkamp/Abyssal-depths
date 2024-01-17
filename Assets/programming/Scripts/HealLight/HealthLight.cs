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
    public AudioSource healingSound;

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < healingRange)
        {
            healthSlider.value += healthGainSpeed * Time.deltaTime;
            if(healingSound.isPlaying == false)
            {
                healingSound.Play();
            }
        }

        else if(healingSound.isPlaying)
        {
            healingSound.Pause();
        }
    }
}
