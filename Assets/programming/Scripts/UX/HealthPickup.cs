using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    public float hpGain;
    public float widthGain;
    public GameObject slider;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<Health>().healthSlider.maxValue += hpGain;
                other.gameObject.GetComponent<Health>().healthSlider.value += hpGain;
                RectTransform sliderRect = slider.GetComponent<RectTransform>();
                sliderRect.sizeDelta = new Vector2(sliderRect.sizeDelta.x + widthGain, sliderRect.sizeDelta.y);

                Destroy(gameObject);
            }
        }


    }
}
