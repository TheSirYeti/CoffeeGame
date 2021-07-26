using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Rshaid, Juan Pablo
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
        }
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
