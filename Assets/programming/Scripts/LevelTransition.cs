using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public CameraPlayerPosition cinemachineCam;

    public Transform nextPlayerPosition;
    public Transform nextCameraPosition;
 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = nextPlayerPosition.position;
            cam.transform.position = nextCameraPosition.position;
            cinemachineCam.currentLevelCam = nextCameraPosition;
        }
    }
}
