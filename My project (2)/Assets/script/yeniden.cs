using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStartScene : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeactivate;

    private void OnMouseDown()
    {
        // Belirtilen nesnenin aktifliðini kapat
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogError("Deactivate edilecek nesne atanmamýþ!");
        }



        // Baþlangýç sahnesine dönme iþlemi
        SceneManager.LoadScene(1); // 0, baþlangýç sahnesinin build index'i
                                   // TimeScale'i 1'e ayarla (oyunu normal hýzda çalýþtýr)
        Time.timeScale = 1f;
    }
}