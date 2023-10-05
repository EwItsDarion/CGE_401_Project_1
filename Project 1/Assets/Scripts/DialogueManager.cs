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
    public bool empty;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();    
    }

    public void StartDialogue(Dialogue dialogue) {
        dialogueBox.SetActive(true);
        sentences.Clear();
        foreach ( var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        empty = false;

        DisplayNextSentence();
    }

    public void DisplayNextSentence() { 
        
        if (sentences.Count == 0) {
            empty = true;
            EndDialogue();
            return;
        }

        var sentence = sentences.Dequeue();

        var split = sentence.Split('#');
        //split string into multiple parts for rendering
        nameText.text = split[0];
        dialogueText.text = split[1];
    }

    public void EndDialogue() {
        dialogueBox.SetActive(false);
        Debug.Log("End Conversation");
    }
}
