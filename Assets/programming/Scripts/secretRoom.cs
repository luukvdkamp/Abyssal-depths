using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretRoom : MonoBehaviour
{
    public Light lightBulb;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(SmoothIntensityChange(lightBulb.intensity, 800, 1));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SmoothIntensityChange(lightBulb.intensity, 0, 1));
        }
    }

    private IEnumerator SmoothIntensityChange(float startIntensity, float targetIntensity, float duration)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            // Interpolate the intensity over time
            lightBulb.intensity = Mathf.Lerp(startIntensity, targetIntensity, currentTime / duration);

            currentTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final intensity is set
        lightBulb.intensity = targetIntensity;
    }
}
