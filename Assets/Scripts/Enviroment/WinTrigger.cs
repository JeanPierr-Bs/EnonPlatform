using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel; // Referencia a la UI de victoria
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca la meta
        {
            WinGame();
        }
    }
    void WinGame()
    {
        Debug.Log("¡Has ganado!");
        winPanel.SetActive(true); // Muestra la pantalla de victoria
        Time.timeScale = 0; // Pausa el juego
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
