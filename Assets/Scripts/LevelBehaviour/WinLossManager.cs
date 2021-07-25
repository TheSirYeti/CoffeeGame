using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TP2 - Rshaid, Juan Pablo
public class WinLossManager : MonoBehaviour
{
    [SerializeField] List<GameObject> UIElements;
    public GameObject winPanel, losePanel;
    public FadeManager fadeManager;
    public CursorState cursorState;
    public GameObject music;

    private void Start()
    {
        EventManager.Subscribe("Lose", DisableUI);
        EventManager.Subscribe("Lose", Lose);
        EventManager.Subscribe("Win", Win);
    }

    public void DisableUI(object[] parameters)
    {
        foreach (GameObject g in UIElements)
        {
            g.SetActive(false);
        }
    }

    public void Lose(object[] parameters)
    {
        StartCoroutine(SetEndPanel(losePanel));
    }

    public void Win(object[] parameters)
    {
        StartCoroutine(SetEndPanel(winPanel));
    }

    IEnumerator SetEndPanel(GameObject panel)
    {
        fadeManager.fade();
        yield return new WaitForSeconds(1.1f);
        panel.SetActive(true);
        cursorState.end();
    }

    public void LoadNextScene(int id)
    {
        if (id == (int)SceneID.MAINMENU)
            SoundManager.instance.StopMusic(MusicID.MAINSONG);


        SoundManager.instance.StopAllSounds();
        EventManager.resetEventDictionary();
        SceneManager.LoadScene(id);
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
