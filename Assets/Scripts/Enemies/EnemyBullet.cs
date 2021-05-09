using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float  speed;
    
    void Update()
    {
        //cambiamos la posicion de la bullet para que esta se mueva hacia adelante
        transform.position += transform.forward * speed * Time.deltaTime; 
              
    }

    void OnCollisionEnter (Collision collision)
    {
        //En caso de que colisione con el jugador, esta sera destruida y le causara dano al mismo
        if(collision.gameObject.tag.Equals("Player"))
        {
            Death();
        }
    }
    void Death ()
    {
        Destroy(gameObject);
    }
    
}
