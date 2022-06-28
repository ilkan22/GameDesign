using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Image dialogSprite;
    public Animator animator;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }
    public void StartDialog(Dialog dialog, Sprite sprite)
    {
        
        animator.SetBool("IsOpen", true);
        Debug.Log("Dialog getstartet");
        sentences.Clear();
        dialogSprite.GetComponent<Image>().sprite = sprite;
        foreach (string sentence in dialog.sentences)
        {
            
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        Time.timeScale = 0f;

    }
    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence =sentences.Dequeue();
        dialogText.text = sentence;
    }
    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("Ende Dialog");

        Time.timeScale = 1f;
    }
}
