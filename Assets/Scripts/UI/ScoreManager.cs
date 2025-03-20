using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private int score = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // A�ade puntos y actualiza la UI
    public void AddPoints(int points)
    {
        if (points > 0)
        {
            score += points;
            UiManager.Instance.UpdateScore(score);
            Debug.Log("Puntos: " + score);
        }
    }
    // Obtiene la puntuaci�n actual
    public int GetScore()
    {
        return score;
    }
    // M�todo para reiniciar la puntuaci�n (Llamar al perder todas las vidas o reiniciar nivel)
    public void ResetScore()
    {
        score = 0;
        UiManager.Instance.UpdateScore(score);
        Debug.Log("Puntos reiniciados");
    }
}
