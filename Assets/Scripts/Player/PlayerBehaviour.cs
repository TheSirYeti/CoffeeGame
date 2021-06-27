using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Rshaid, Juan Pablo
public abstract class PlayerBehaviour : MonoBehaviour
{
    public float hp;

    public void TakeDamage()
    {
        hp--;       //Loses an HP point
        EventManager.Trigger("LoseLife");
    }

    private void Update()
    {
        if (hp <= 0)
            EventManager.Trigger("Lose");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")        //If it collides with an enemy, it takes damage.
        {
            SoundManager.instance.PlaySound(SoundID.TAKEDAMAGE);    //Plays a sound effect
            TakeDamage();
        }
    }
}
