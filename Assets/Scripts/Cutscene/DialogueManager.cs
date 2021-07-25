using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueBox;
    public string[] sentences;
    public int[] animationPerSentence;
    int currentIndex = 0;
    public float characterSpeed;

    bool isSentenceOver;
    string currentSentence;
    public Animator animator;
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
                Destroy(gameObject);
            } else
            {
                currentSentence = sentences[currentIndex];
                StartCoroutine(Typing());
            }
        }
    }

    void PlayAnimator(int animationID)
    {
        switch (animationID)
        {
            case 1:
                animator.Play("Nod");
                break;
            case 2:
                animator.Play("Idk");
                break;
            case 3:
                animator.Play("Wave");
                break;
            case 4:
                animator.Play("ThumbsUp");
                break;
            default:
                break;
        }
    }
}
