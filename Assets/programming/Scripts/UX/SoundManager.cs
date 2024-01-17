using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundAmbience;
    public AudioSource metalDamage;
    public AudioSource gameOver;
    public AudioSource damage;
    public bool gotHit;
    public GameOver gameOverCode;
    public bool damaged;

    void Update()
    {
        if(gotHit)
        {
            metalDamage.Play();
            gotHit = false;
        }

        if(gameOverCode.isGameOver)
        {
            if(gameOver.isPlaying == false)
            {
                gameOver.Play();
            }
        }

        if(damaged)
        {
            damage.Play();
            damaged = false;
        }
    }
}
