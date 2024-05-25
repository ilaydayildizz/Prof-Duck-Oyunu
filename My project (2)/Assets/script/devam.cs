using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameAndDeactivateObject : MonoBehaviour
{
    public GameObject objectToDeactivate; // Devre dýþý býrakýlacak nesne

    void Update()
    {
        // Mouse sol tuþuna basýldýðýnda kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse pozisyonunu dünya koordinatlarýna çevir
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Mouse týklamasýný kontrol et
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // Raycast'i kullanarak mouse'un týkladýðý nesneyi kontrol et
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Oyunu devam ettir
                Time.timeScale = 1f;

                // Belirtilen nesneyi devre dýþý býrak
                objectToDeactivate.SetActive(false);
            }
        }
    }
}