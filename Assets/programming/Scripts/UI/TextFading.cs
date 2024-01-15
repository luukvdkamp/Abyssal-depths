using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFading : MonoBehaviour
{
    public float fadeDuration = 1.0f;

    private CanvasGroup canvasGroup;
    private bool isFading = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1.0f, 0.0f, fadeDuration));
            yield return new WaitForSeconds(1.0f); // Wait for 1 second between fades
            yield return StartCoroutine(Fade(0.0f, 1.0f, fadeDuration));
        }
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        if (isFading)
            yield break;

        isFading = true;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        isFading = false;
    }
}
