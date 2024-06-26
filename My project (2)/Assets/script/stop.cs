using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameAndActivateObject : MonoBehaviour
{
    public GameObject objectToActivate; // Aktive edilecek nesne

    void Update()
    {
        // Mouse sol tuşuna basıldığında kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast kullanarak mouse tıklamasını kontrol et
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // Raycast'i kullanarak mouse'un tıkladığı nesneyi kontrol et
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Oyunu duraklat
                Time.timeScale = 0f;

                // Belirtilen nesneyi etkinleştir
                objectToActivate.SetActive(true);
            }
        }
    }
}