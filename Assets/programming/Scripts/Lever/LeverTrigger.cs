using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public GameObject[] doors;
    public Animator animator;
    public AudioSource leverPull;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if(doors[i].activeInHierarchy)
                {
                    doors[i].gameObject.SetActive(false);
                }

                else
                {
                    doors[i].gameObject.SetActive(true);
                }
            }
            animator.SetBool("leverPulled", true);
            leverPull.Play();
        }
    }
}
