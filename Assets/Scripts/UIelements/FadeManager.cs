using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TP2 - Rshaid, Juan Pablo

public class FadeManager : MonoBehaviour
{
    public Animator animator;


    public void fade()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("fadeOut");     //Sets a parameter which fades the screen to black
    }
}
