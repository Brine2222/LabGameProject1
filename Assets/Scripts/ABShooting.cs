using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ABShooting : MonoBehaviour
{
    public KeyCode Return;
    public Transform shootingPoint;
    public GameObject bullet;
    public SpriteRenderer sr;

    public AudioClip shootSound; // drag your shooting audio clip here in the Inspector

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(Return))
        {
            Shooting(); //see function definition below
        }
    }

    public void Shooting()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);

        // play the shooting sound through the AudioManager's SFX source (if a clip is assigned)
        if (shootSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusicSFX(shootSound);
        }
    }
}