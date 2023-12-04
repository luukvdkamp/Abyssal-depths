using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    public Slider healthSlider;
    public AudioSource fallingSound;
    public float minFallingTime;
    private float fallingTime;

    public float velocityy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocityy = GetComponent<Rigidbody>().velocity.y;
        if (GetComponent<Rigidbody>().velocity.y < 0 && GetComponent<Rigidbody>().useGravity && movementPlayer.isGrounded == false)
        {
            fallingTime += Time.deltaTime;
            if(fallingSound.isPlaying == false)
            {
                fallingSound.Play();
            }
            
        }
        else
        {
            fallingTime = 0;
            fallingSound.Stop();
        }

        if(fallingTime > minFallingTime)
        {
            healthSlider.value -= fallingTime;
            fallingTime = 0;
            fallingSound.Stop();
        }
        
    }
}
