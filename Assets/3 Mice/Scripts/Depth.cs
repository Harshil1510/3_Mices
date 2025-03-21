using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Depth : MonoBehaviour
{
    public Text depthText;
    public GameObject gameOverPanel;
    private float startY;
    private int maxDepth = 0;
    private bool hasStarted = false;

    void Start()
    {
        startY = transform.position.y;
        depthText.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        int depth = Mathf.FloorToInt(startY - transform.position.y);
        if (!hasStarted && depth > 0)
        {
            depthText.gameObject.SetActive(true);
            hasStarted = true;
        }
        if (depth > maxDepth)
        {
            maxDepth = depth;
            depthText.text = "" + maxDepth.ToString();
        }
        if (transform.position.y < -250)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}

