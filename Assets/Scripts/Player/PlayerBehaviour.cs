using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviour : MonoBehaviour
{
    public float hp;
    

    public void takeDamage()
    {
        hp--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            takeDamage();
        }
    }
}
