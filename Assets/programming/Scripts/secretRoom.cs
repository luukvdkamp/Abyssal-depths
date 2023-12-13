using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretRoom : MonoBehaviour
{
    public Light lightBulb;
    public Light playerLight;
    private float playerLightIntensity;

    public void Start()
    {
        playerLightIntensity = playerLight.intensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(SmoothIntensityChange(lightBulb.intensity, 100, 1));

            StartCoroutine(SmoothPlayerIntensityChange(playerLight.intensity, 0, 1));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SmoothIntensityChange(lightBulb.intensity, 0, 1));

            StartCoroutine(SmoothPlayerIntensityChange(playerLight.intensity, playerLightIntensity, 1));
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

    private IEnumerator SmoothPlayerIntensityChange(float startIntensity, float targetIntensity, float duration)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            // Interpolate the intensity over time
            playerLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, currentTime / duration);

            currentTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final intensity is set
        playerLight.intensity = targetIntensity;
    }
}
