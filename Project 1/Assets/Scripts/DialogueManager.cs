using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;
    public GameManager manager;
    public bool empty;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();
        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        empty = false;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            empty = true;
            EndDialogue();
            return;
        }

        var sentence = sentences.Dequeue();
        //split string into multiple parts for rendering
        var split = sentence.Split('#');
        print(split[0].Trim());
        //conditional rendering for dialogue with level system
        int level;
        if (int.TryParse(split[0], out level) && level == GameManager.currentLevel)
        {
            nameText.text = split[1];
            dialogueText.text = split[2];
        }

        else
        {
            DisplayNextSentence();
        }

    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Debug.Log("End Conversation");
    }
}
