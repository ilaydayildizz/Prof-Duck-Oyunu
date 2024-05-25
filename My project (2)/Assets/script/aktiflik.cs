using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject object1; // Ýlk nesne
    public GameObject object2; // Ýkinci nesne
    public GameObject clickableObject; // Týklanacak nesne

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol mouse butonuna týklandýðýnda
        {
            CheckForClick();
        }
    }

    void CheckForClick()
    {
        // Mouse pozisyonunu dünya koordinatlarýna çevir
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider = clickableObject.GetComponent<Collider2D>();

        if (collider == Physics2D.OverlapPoint(mousePosition))
        {
            ToggleActiveState();
        }
    }

    void ToggleActiveState()
    {
        // Ýlk nesnenin aktifliðini tersine çevir
        object1.SetActive(!object1.activeSelf);
        // Ýkinci nesnenin aktifliðini tersine çevir
        object2.SetActive(!object2.activeSelf);
    }
}