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
    public void AddPoints(int points)
    {
        if (points > 0)
        {
            score += points;
            UiManager.Instance.UpdateScore(score);
            Debug.Log("Puntos: " + score);
        }
    }
    public int GetScore()
    {
        return score;
    }
}
