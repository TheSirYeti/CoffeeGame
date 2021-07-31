using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TP Final - Juan Pablo Rshaid

public class FadeManager : MonoBehaviour
{
    public Animator animator;


    public void fade()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("fadeOut");     //Sets a parameter which fades the screen to black
    }
}
