using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("EnonPlatform"); // Cambia esto por el nombre real de la escena del nivel
    }
    public void QuitGame()
    {
        Application.Quit(); // Cierra el juego (solo funciona en builds, no en el editor)
    }
}
