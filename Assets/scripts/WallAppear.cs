using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAppear : MonoBehaviour
{
    public GameObject objectToAppear;   // Reference to the GameObject to appear

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectToAppear.SetActive(true);
        }
    }
}
