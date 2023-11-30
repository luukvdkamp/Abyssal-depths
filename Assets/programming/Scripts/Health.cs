using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    public Slider healthSlider;
    private float timeInAir;
    public float minimumFallDamageTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player in air
        if(movementPlayer.isGrounded == false && GetComponent<Rigidbody>().useGravity) //check if on rope
        {
            timeInAir += Time.deltaTime;
        }

        else
        {
            if (timeInAir > minimumFallDamageTime)
            {
                healthSlider.value -= timeInAir;
            }

            //reset air time
            timeInAir = 0;
        }

        
    }
}
