using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundController : MonoBehaviour
{
    public AudioClip[] collisionSounds; // �arp��ma sesleri dizisi (farkl� sesler i�in)

    private AudioSource collisionAudioSource;

    void Start()
    {
        collisionAudioSource = GetComponent<AudioSource>();
        if (collisionAudioSource == null)
        {
            Debug.LogError("AudioSource bulunamad�. Script'i bu GameObject'e ekledi�inizden emin olun.");
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
            // �arp��ma seslerinden rastgele birini se�
            int index = Random.Range(0, collisionSounds.Length);
            collisionAudioSource.clip = collisionSounds[index];
            collisionAudioSource.Play();
        }
    }
}