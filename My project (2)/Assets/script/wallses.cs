using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnWallCollision : MonoBehaviour
{
    public AudioSource audioSource; // M�zik kayna��

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Di�er nesnenin etiketini kontrol et (tag)
        if (other.CompareTag("wall"))
        {
            // M�zi�i �al
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}