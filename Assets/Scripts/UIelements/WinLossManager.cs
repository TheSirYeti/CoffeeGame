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

    public void loadNextScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
