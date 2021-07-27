using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueBox;
    public string[] sentences;
    public AnimationStyle[] animationPerSentence;
    int currentIndex = 0;
    public float characterSpeed;
    public Image background;
    public Text extraText;

    bool isSentenceOver;
    string currentSentence;
    public Animator animator;

    public FadeManager fade;
    public int sceneToLoad;

    private void Start()
    {
        currentSentence = sentences[currentIndex];
        StartCoroutine(Typing());
    }
    IEnumerator Typing()
    {
        isSentenceOver = false;
        PlayAnimator(animationPerSentence[currentIndex]);
        for(int i = 0; i <= currentSentence.Length; i++)
        {
            dialogueBox.text = currentSentence.Substring(0, i);
            yield return new WaitForSeconds(characterSpeed);
        }
        isSentenceOver = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && isSentenceOver)
        {
            dialogueBox.text = "";
            currentIndex++;
            if (currentIndex >= sentences.Length)
            {
                background.enabled = false;
                dialogueBox.enabled = false;
                extraText.enabled = false;
                StartCoroutine(EndCutscene());
            } else
            {
                currentSentence = sentences[currentIndex];
                StartCoroutine(Typing());
            }
        }
    }

    void PlayAnimator(AnimationStyle style)
    {
        switch (style)
        {
            case AnimationStyle.NOD:
                animator.Play("Nod");
                break;
            case AnimationStyle.IDK:
                animator.Play("Idk");
                break;
            case AnimationStyle.WAVE:
                animator.Play("Wave");
                break;
            case AnimationStyle.THUMBSUP:
                animator.Play("ThumbsUp");
                break;
            default:
                break;
        }
    }

    IEnumerator EndCutscene()
    {
        fade.fade();
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public enum AnimationStyle
    {
        NOD,
        IDK,
        WAVE,
        THUMBSUP,
        NONE
    }
}
