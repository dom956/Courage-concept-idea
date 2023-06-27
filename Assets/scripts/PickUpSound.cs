using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSound : MonoBehaviour
{
    public AudioClip pickupSound;      // Reference to the audio clip
    public AudioSource audioSource;    // Reference to the AudioSource component

    private bool hasBeenPickedUp = false;   // Flag to track if the object has been picked up

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasBeenPickedUp)
        {
            hasBeenPickedUp = true;

            // Play the sound effect
            if (audioSource != null && pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            // Destroy the object upon player interaction
           
        }
    }
}
