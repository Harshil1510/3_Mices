using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static bool IsGameOver { get; internal set; }

    void Start()
    {
        gameOverPanel.SetActive(false); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            gameOverPanel.SetActive(true); 
            Time.timeScale = 0;
        }
    }
}

