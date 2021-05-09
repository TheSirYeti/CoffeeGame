using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Animator animator;
    public int sceneToLoad;

    public void fade()
    {
        StartCoroutine(fading(sceneToLoad));
    }

    IEnumerator fading(int scene)
    {
        animator.SetTrigger("fadeOut");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(scene);
    }
}
