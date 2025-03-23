using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winPanel; // Referencia a la UI de victoria
    public int soundToPlay;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca la meta
        {
            WinGame();
        }
    }
    void WinGame()
    {
        winPanel.SetActive(true); // Muestra la pantalla de victoria
        SoundManager.instance.PlaySfx(soundToPlay);
        Time.timeScale = 0; // Pausa el juego
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
