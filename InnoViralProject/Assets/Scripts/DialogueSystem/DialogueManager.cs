using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text continueButton;
    public GameObject dialogueBox;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        dialogueBox.SetActive(true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string s =  sentences.Dequeue();
        dialogueText.text = s;

        if(sentences.Count == 0)
        {
            continueButton.text = "Finish";
        }
    }

    void EndDialogue()
    {
        continueButton.text = "Continue";
        dialogueBox.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("End of conversation");
    }
}
