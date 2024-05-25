using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStartSceneOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        ReturnToStartScene();
    }

    private void ReturnToStartScene()
    {
        SceneManager.LoadScene(0); // 0, baþlangýç sahnesinin build index'i
    }
}