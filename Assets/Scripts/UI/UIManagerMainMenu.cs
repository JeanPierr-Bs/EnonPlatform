using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private float transitionTime = 0.5f;
    private CanvasGroup canvasGroup;
    private Coroutine transitionCoroutine;

    private void Awake()
    {
        canvasGroup = optionsPanel.GetComponent<CanvasGroup>() ?? optionsPanel.AddComponent<CanvasGroup>();
        optionsPanel.SetActive(false);
        canvasGroup.alpha = 0;
    }
    public void ToggleOptions()
    {
        bool opening = !optionsPanel.activeSelf;

        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        optionsPanel.SetActive(true);
        transitionCoroutine = StartCoroutine(FadeCanvas(canvasGroup, opening));
    }
    private IEnumerator FadeCanvas(CanvasGroup canvas, bool opening)
    {
        float startAlpha = canvas.alpha;
        float endAlpha = opening ? 1 : 0;
        float elapsedTime = 0f;

        while (elapsedTime < transitionTime)
        {
            canvas.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvas.alpha = endAlpha;
        if (!opening) optionsPanel.SetActive(false);
    }
}
