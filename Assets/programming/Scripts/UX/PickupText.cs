using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupText : MonoBehaviour
{
    public GameObject inputText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inputText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inputText.SetActive(false);
        }
    }
}
