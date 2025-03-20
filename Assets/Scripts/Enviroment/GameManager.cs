using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Reiniciando el nivel...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
