using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuGameObject;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuGameObject.activeInHierarchy)
            {
                pauseMenuGameObject.SetActive(false);
                Time.timeScale = 1;
            }
            
            else
            {
                pauseMenuGameObject.SetActive(true);
                Time.timeScale = 0;
            }
           
        }


        //bug return button
        if(pauseMenuGameObject.activeInHierarchy == false && Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }
}
