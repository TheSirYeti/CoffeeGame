using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Animator animator;

    public void fade()
    {
        animator.SetTrigger("fadeOut");
    }
}
