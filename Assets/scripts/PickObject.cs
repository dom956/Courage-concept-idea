
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public ParticleSystem pickupEffect;      // Reference to the particle effect

    private bool hasPlayedEffect = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (collision.CompareTag("Player") && !hasPlayedEffect)
            {
                hasPlayedEffect = true;

                // Play the particle effect
                if (pickupEffect != null)
                {
                    pickupEffect.Play();
                    
                }

                // Disable the collider to prevent repeated triggers
                GetComponent<Collider2D>().enabled = false;
            }

        }
    }

     

}

   