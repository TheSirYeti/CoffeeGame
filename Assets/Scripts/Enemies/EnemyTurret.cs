using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Juan Cruz Cristófalo
public class EnemyTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform  firePoint;

    void Shoot()
    {
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation); //Instantiates the bullet on the desired position
        SoundManager.instance.PlaySound(SoundID.PAPER_BALL);  
    }
          
}
