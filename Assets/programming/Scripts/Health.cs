using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider; //health bar
    public MovementPlayer movementPlayer;
    public PlayerAnimations playerAnimations;
    public GameOver gameOver;

    public bool gotHit;
    public float damage;

    //fall damage
    public float minFallingTime;
    private float fallingTime;
    public float velocityY;

    [Header("UX")]
    public AudioSource fallingSound;
    public AudioSource landingSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FallDamage();
        GettingDamage();

        if (healthSlider.value == 0)
        {
            movementPlayer.enabled = false;

            gameOver.isGameOver = true;
        }
    }

    void GettingDamage()
    {
        //if damage
        if(damage != 0 && playerAnimations.gameOver == false)
        {
            healthSlider.value -= damage;

            //if game over
            if(healthSlider.value == 0)
            {
                playerAnimations.gameOver = true;

            }

            else
            {
                playerAnimations.damagePlayer = true;
            }

            damage = 0;
        }
    }

    void FallDamage()
    {
        velocityY = GetComponent<Rigidbody>().velocity.y;
        if (GetComponent<Rigidbody>().velocity.y < 0 && GetComponent<Rigidbody>().useGravity && movementPlayer.isGrounded == false)
        {
            fallingTime += Time.deltaTime;
            if (fallingSound.isPlaying == false)
            {
                fallingSound.Play();
            }

        }

        else
        {
            fallingTime = 0;
            fallingSound.Stop();
        }

        if (fallingTime > minFallingTime)
        {
            healthSlider.value -= fallingTime;
            fallingTime = 0;
            fallingSound.Stop();
            landingSound.Play();
        }
    }
}
