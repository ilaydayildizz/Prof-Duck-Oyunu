using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToggleAllMusicOnClick : MonoBehaviour
{
    private bool isPlaying = false; // Müzik çalınıyor mu?

    private void OnMouseDown()
    {
        // Tüm ses kaynaklarını bul
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Eğer müzik çalıyorsa durdur, değilse başlat
        if (isPlaying)
        {
            foreach (AudioSource audioSource in allAudioSources)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            isPlaying = false;
        }
        else
        {
            foreach (AudioSource audioSource in allAudioSources)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
            isPlaying = true;
        }
    }
}
