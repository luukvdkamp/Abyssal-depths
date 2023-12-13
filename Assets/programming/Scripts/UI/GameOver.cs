using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public bool isGameOver;
    public Slider healthSlider;

    public Image blackBackground;
    public GameObject gameOverText;
    public GameObject returnButton;

    public float fadeDuration;

    void Update()
    {
        if(isGameOver)
        {
            StartCoroutine(FadeImage());
            healthSlider.enabled = false;
        }


    }


    IEnumerator FadeImage()
    {
        // Get the current alpha value of the image
        float currentAlpha = blackBackground.color.a;

        // Target alpha value (e.g., fully opaque)
        float targetAlpha = 1f;

        // Time elapsed
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Interpolate the alpha value smoothly
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Update the image's color with the new alpha value
            blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, newAlpha);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the image is fully opaque
        blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, targetAlpha);
        gameOverText.SetActive(true);
        returnButton.SetActive(true);
    }
}
