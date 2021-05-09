﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float  speed;
    
    void Update()
    {
        //cambiamos la posicion de la bullet para que esta se mueva hacia adelante
        transform.position += transform.forward * speed * Time.deltaTime; 

        Destroy(gameObject, 5f);

    }

    void OnTriggerEnter (Collision other)
    {
        //En caso de que colisione con el jugador, esta sera destruida y le causara dano al mismo
        if(other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
    
}
