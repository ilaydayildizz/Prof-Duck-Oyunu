using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText; // Birinci TextMeshPro referans�
    public TextMeshPro gameOverText; // �kinci TextMeshPro referans�
    private int score = 0; // Skor ba�lang�� de�eri
    private bool gameOver = false; // Oyunun bitip bitmedi�ini kontrol etmek i�in flag

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
                 // �arpt���n�z food objesini yok eder
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