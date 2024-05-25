using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject object1; // �lk nesne
    public GameObject object2; // �kinci nesne
    public GameObject clickableObject; // T�klanacak nesne

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol mouse butonuna t�kland���nda
        {
            CheckForClick();
        }
    }

    void CheckForClick()
    {
        // Mouse pozisyonunu d�nya koordinatlar�na �evir
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider = clickableObject.GetComponent<Collider2D>();

        if (collider == Physics2D.OverlapPoint(mousePosition))
        {
            ToggleActiveState();
        }
    }

    void ToggleActiveState()
    {
        // �lk nesnenin aktifli�ini tersine �evir
        object1.SetActive(!object1.activeSelf);
        // �kinci nesnenin aktifli�ini tersine �evir
        object2.SetActive(!object2.activeSelf);
    }
}