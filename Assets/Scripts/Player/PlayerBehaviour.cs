using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid
public abstract class PlayerBehaviour : MonoBehaviour
{
    public float hp;
    public bool shield;

    private void Awake()
    {

    }

    public void TakeDamage()
    {
        if (!shield)
        {
            hp--;       //Loses an HP point
            EventManager.Trigger("LoseLife");
            SoundManager.instance.PlaySound(SoundID.TAKEDAMAGE);    //Plays a sound effect
        } else SoundManager.instance.PlaySound(SoundID.BLOCK);
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
            TakeDamage();
        }
    }

    public void ActivateShield(object[] parameters)
    {
        shield = true;
        Debug.Log("ACTIVADO");
    }

    public void DisableShield(object[] parameters)
    {
        shield = false;
        Debug.Log("DESACTIVADO");
    }
}
