using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject gun;
    public GameObject knife;

    private bool resetParry;
    public float maxParryTime;
    private float parryCount;

    private bool parryCooldown;
    public float maxParryCooldown;
    private float parryCooldownCount;

    public AudioSource parry;


    private void Update()
    {
        if(Input.GetButtonDown("Fire2") && parryCooldown == false)
        {
            knife.SetActive(true);
            gun.SetActive(false);
            parry.Play();

            resetParry = true;
        }

        //decide the time the parry lasts
        if(resetParry)
        {
            parryCount += Time.deltaTime;
            if(parryCount > maxParryTime)
            {
                resetParry = false;
                parryCount = 0;

                knife.SetActive(false);
                gun.SetActive(true);

                //give parry cooldown
                parryCooldown = true;
            }
        }

        //cooldown
        if(parryCooldown)
        {
            parryCooldownCount += Time.deltaTime;
            if(parryCooldownCount > maxParryCooldown)
            {
                parryCooldownCount = 0;
                parryCooldown = false;
            }
        }
    }
}
