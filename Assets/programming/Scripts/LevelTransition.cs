using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public Transform nextPlayerPosition;
    public Transform nextCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = nextPlayerPosition.position;
            cam.transform.position = nextCameraPosition.position;
        }
    }
}
