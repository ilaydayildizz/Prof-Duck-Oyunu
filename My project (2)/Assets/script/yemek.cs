using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundController : MonoBehaviour
{
    public AudioClip[] collisionSounds; // Çarpýþma sesleri dizisi (farklý sesler için)

    private AudioSource collisionAudioSource;

    void Start()
    {
        collisionAudioSource = GetComponent<AudioSource>();
        if (collisionAudioSource == null)
        {
            Debug.LogError("AudioSource bulunamadý. Script'i bu GameObject'e eklediðinizden emin olun.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            PlayRandomCollisionSound();
        }
    }

    void PlayRandomCollisionSound()
    {
        if (collisionAudioSource != null && collisionSounds.Length > 0)
        {
            // Çarpýþma seslerinden rastgele birini seç
            int index = Random.Range(0, collisionSounds.Length);
            collisionAudioSource.clip = collisionSounds[index];
            collisionAudioSource.Play();
        }
    }
}