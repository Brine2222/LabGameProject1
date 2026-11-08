using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHeart : MonoBehaviour
{
    public AudioClip heartSound;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats.lives++;
            PlayerStats.hasHeart = true;

            AudioManager.Instance.PlayMusicSFX(heartSound);
         
            Debug.Log("Lives: " + PlayerStats.lives);

            Destroy(gameObject);
        }
    }
}

