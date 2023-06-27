
using UnityEngine;

public class FadeControl : MonoBehaviour
{

    public GameObject fadeEffect;

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            fadeEffect.SetActive(true);
        }
            
        
        
    }
}
