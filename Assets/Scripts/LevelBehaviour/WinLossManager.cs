using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossManager : MonoBehaviour
{
    [SerializeField] List<GameObject> UIElements;
    public GameObject winPanel, losePanel;
    public FadeManager fadeManager;
    public CursorState cursorState;
    public GameObject music;

    private void Start()
    {
        music = GameObject.FindWithTag("Music");        //Gets the object that's playing music
    }

    public void disableUI()
    {
        foreach (GameObject g in UIElements)
        {
            g.SetActive(false);
        }
    }

    public void lose()
    {
        StartCoroutine(setEndPanel(losePanel));
    }

    public void win()
    {
        StartCoroutine(setEndPanel(winPanel));
    }

    IEnumerator setEndPanel(GameObject panel)
    {
        fadeManager.fade();
        yield return new WaitForSeconds(0.75f);
        panel.SetActive(true);
        cursorState.end();
    }

    public void loadNextScene(SceneID id)
    {
        if (id == SceneID.MAINMENU)
            SoundManager.instance.StopMusic(MusicID.MAINSONG);

        SceneManager.LoadScene((int)id);
    }

    public enum SceneID
    {
        MAINMENU,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        LEVEL4
    }
}
