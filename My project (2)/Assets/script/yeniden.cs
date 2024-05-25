using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStartScene : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeactivate;

    private void OnMouseDown()
    {
        // Belirtilen nesnenin aktifli�ini kapat
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogError("Deactivate edilecek nesne atanmam��!");
        }



        // Ba�lang�� sahnesine d�nme i�lemi
        SceneManager.LoadScene(1); // 0, ba�lang�� sahnesinin build index'i
                                   // TimeScale'i 1'e ayarla (oyunu normal h�zda �al��t�r)
        Time.timeScale = 1f;
    }
}