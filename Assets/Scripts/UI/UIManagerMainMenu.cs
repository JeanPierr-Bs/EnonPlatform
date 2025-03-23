using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = optionsPanel.GetComponent<CanvasGroup>() ?? optionsPanel.AddComponent<CanvasGroup>();
        optionsPanel.SetActive(false);
    }
    public void ToggleOptions()
    {
        bool opening = optionsPanel.activeSelf;
        optionsPanel.SetActive(!opening);

        // Asegurar que el CanvasGroup se active/desactive correctamente
        canvasGroup.alpha = opening ? 0 : 1;
        canvasGroup.interactable = !opening;
        canvasGroup.blocksRaycasts = !opening;

        Canvas.ForceUpdateCanvases(); //Refrescar la UI por si acaso
    }
  
}
