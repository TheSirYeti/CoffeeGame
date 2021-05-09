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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 4.2f / fireRate;

            mAudioSrc.Play();
        }

        
        
        fireCountdown -= Time.deltaTime; 
                
    }

    void Shoot()
    {
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
