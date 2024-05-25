using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusicOnClick : MonoBehaviour
{
    public AudioSource musicSource; // Müzik kaynağı

    private void OnMouseDown()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause(); // Müziği duraklat
        }
        else
        {
            musicSource.Play(); // Müziği çal
        }
    }
}