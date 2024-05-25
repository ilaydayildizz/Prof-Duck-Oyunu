using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnWallCollision : MonoBehaviour
{
    public AudioSource audioSource; // Müzik kaynaðý

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Diðer nesnenin etiketini kontrol et (tag)
        if (other.CompareTag("wall"))
        {
            // Müziði çal
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}