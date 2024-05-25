using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText; // Birinci TextMeshPro referansý
    public TextMeshPro gameOverText; // Ýkinci TextMeshPro referansý
    private int score = 0; // Skor baþlangýç deðeri
    private bool gameOver = false; // Oyunun bitip bitmediðini kontrol etmek için flag

    void Start()
    {
        UpdateScoreText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food"))
        {
            if (!gameOver)
            {
                score++;
                UpdateScoreText();
                 // Çarptýðýnýz food objesini yok eder
            }
        }
        else if (other.CompareTag("wall"))
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    void GameOver()
    {
        gameOver = true;
        gameOverText.text = "GAME OVER\nSkor: " + score.ToString();
    }
}