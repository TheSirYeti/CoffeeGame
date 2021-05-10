using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public  float fireRate      = 1f;
    private float fireCountdown = 1.9f;

    public GameObject bulletPrefab;
    public Transform  firePoint;

    public AudioSource mAudioSrc;
    void Update()
    {
        if(fireCountdown <= 0f)     //If it's allowed to fire, it fires
        {
            Shoot();
            fireCountdown = 4.2f / fireRate;

            mAudioSrc.Play();       //Plays a sound effect
        }

        
        
        fireCountdown -= Time.deltaTime; 
                
    }

    void Shoot()
    {
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);     //Instantiates the bullet on the desired position
    }
}
