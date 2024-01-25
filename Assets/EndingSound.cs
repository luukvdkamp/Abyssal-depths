using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingSound : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource explosion;
    public AudioSource engine;

    public float elapsedTime;

    private void Start()
    {
        engine.Play();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 20)
        {
            explosion.Play();
        }

    }
}
