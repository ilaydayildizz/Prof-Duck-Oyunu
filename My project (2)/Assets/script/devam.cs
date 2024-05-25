using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameAndDeactivateObject : MonoBehaviour
{
    public GameObject objectToDeactivate; // Devre d��� b�rak�lacak nesne

    void Update()
    {
        // Mouse sol tu�una bas�ld���nda kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse pozisyonunu d�nya koordinatlar�na �evir
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Mouse t�klamas�n� kontrol et
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // Raycast'i kullanarak mouse'un t�klad��� nesneyi kontrol et
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Oyunu devam ettir
                Time.timeScale = 1f;

                // Belirtilen nesneyi devre d��� b�rak
                objectToDeactivate.SetActive(false);
            }
        }
    }
}