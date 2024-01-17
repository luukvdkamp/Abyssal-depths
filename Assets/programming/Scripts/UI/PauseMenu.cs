using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuGameObject;

    public Image blackBackground;
    public float fadeDuration;
    public bool isActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuGameObject.activeInHierarchy && isActive)
            {
                Time.timeScale = 1;
                StartCoroutine(FadeOutImageAndCloseMenu());
            }
            else
            {
                StartCoroutine(FadeInImageAndOpenMenu());
            }
        }

        // Bug return button
        if (!pauseMenuGameObject.activeInHierarchy && Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void OnResumeButtonClick()
    {
        if (pauseMenuGameObject.activeInHierarchy && isActive)
        {
            Time.timeScale = 1;
            StartCoroutine(FadeOutImageAndCloseMenu());
        }
        // Additional resume button logic can be added here if needed
    }

    IEnumerator FadeInImageAndOpenMenu()
    {
        float currentAlpha = blackBackground.color.a;
        float targetAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsedTime / fadeDuration);
            blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, targetAlpha);

        // Ensure the image is fully opaque
        pauseMenuGameObject.SetActive(true);
        Time.timeScale = 0;
        isActive = true;
    }

    IEnumerator FadeOutImageAndCloseMenu()
    {
        pauseMenuGameObject.SetActive(false);
        float currentAlpha = blackBackground.color.a;
        float targetAlpha = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsedTime / fadeDuration);
            blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, targetAlpha);

        // Ensure the image is fully transparent
        isActive = false;
    }
}
