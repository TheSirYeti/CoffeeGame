using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicClasses = GameObject.FindGameObjectsWithTag("Music");
        if (musicClasses.Length > 1)
            Destroy(gameObject);

    }
}
