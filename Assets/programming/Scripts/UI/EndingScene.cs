using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndingScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject canvasToShow;

    private float elapsedTime;
    
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= (float)videoPlayer.length)
        {
            canvasToShow.SetActive(true);
        }
        
    }
}
