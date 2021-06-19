using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviour : MonoBehaviour
{
    public float hp;

    public AudioSource damageSound;

    public void takeDamage()
    {
        hp--;       //Loses an HP point
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")        //If it collides with an enemy, it takes damage.
        {
            SoundManager.instance.PlaySound(SoundID.TAKEDAMAGE);    //Plays a sound effect
            takeDamage();
        }
    }
}
