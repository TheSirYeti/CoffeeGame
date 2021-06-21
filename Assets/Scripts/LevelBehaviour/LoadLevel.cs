using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public FadeManager fadeManager;

    public void load(int scene)
    {
        StartCoroutine(loadLevel(scene));       //Starts a coroutine that sets the screen to black.
    }

    public IEnumerator loadLevel(int scene)
    {
        
        fadeManager.fade();                 //Fades the screen to black
        yield return new WaitForSeconds(0.75f);
        SoundManager.instance.StopAllMusic();
        SoundManager.instance.StopAllSounds();
        SceneManager.LoadScene(scene);      //Loads the scene
    }

    public void quit()
    {
        Application.Quit();             //Quits the game
    }
}
