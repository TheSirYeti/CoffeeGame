using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP Final - Juan Pablo Rshaid
public abstract class PowerUp : MonoBehaviour
{
    public PowerType type;
    public float time;
    public float originalTime;
    public bool activated = false;

    [SerializeField] Collider collider;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] GameObject light;

    public abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySound(SoundID.POWERUP_START);
            Activate();
        }
    }

    public enum PowerType
    {
        JUMP_BOOST,
        SPEED_BOOST,
        SHIELD_BOOST
    }

    public void Hide()
    {
        collider.enabled = false;
        meshRenderer.enabled = false;
        light.SetActive(false);
    }
}
