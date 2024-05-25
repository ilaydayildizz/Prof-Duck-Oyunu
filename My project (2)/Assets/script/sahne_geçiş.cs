using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // Tıklanacak hedef nesne

    // Bu metot sahne geçişini yapar
    public void StartGame()
    {
        Time.timeScale = 1f; // Oyun zaman ölçeğini ayarla
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Her karede çağrılan Update metodu
    void Update()
    {
        // Mouse sol tuşuna basıldığında kontrol yap
        if (Input.GetMouseButtonDown(0)) // 0, sol mouse tuşu için
        {
            // Mouse pozisyonunu dünya koordinatlarına çevir
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Raycast kullanarak mouse'un tıkladığı nesneyi kontrol et
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // Raycast'i kullanarak tıklanan nesnenin hedef nesne olup olmadığını kontrol et
            if (hit.collider != null && hit.collider.gameObject == targetObject)
            {
                StartGame();
            }
        }
    }
}