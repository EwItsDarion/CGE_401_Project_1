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
    public Image prof1;
    public Image prof2;
    public Image prof3;
    public Image cou1;
    public Image counselorOffice;
    public Image lounge;
    public Image jessabelle;
    public Image olivia;
    public Image daniel;
    public Image party;

    // Cutscene references
    public GameObject cutsceneDialogueBox;
    public Text cutsceneNameText;
    public Text cutsceneDialogueText;
    public int howMany = 0;

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
        if (GameManager.currentLevel == 2)
        {
            if (manager.cutscene == true)
            {
                howMany++;
                print(howMany);
                print("Current level: " + GameManager.currentLevel);
                prof1.enabled = false;
                prof2.enabled = false;
                prof3.enabled = false;
                cou1.enabled = false;

            }
            if (manager.cutscene == true && howMany >= 2)
            {
                prof1.enabled = true;
                prof2.enabled = false;
                prof3.enabled = false;
                cou1.enabled = false;
            }
            if (manager.cutscene == true && howMany == 3)
            {
                prof1.enabled = false;
                prof2.enabled = false;
                prof3.enabled = true;
                cou1.enabled = false;
            }
            if (manager.cutscene == true && howMany == 5)
            {
                prof1.enabled = false;
                prof2.enabled = true;
                prof3.enabled = false;
                cou1.enabled = false;
            }
            if (manager.cutscene == true && howMany > 5 && howMany <= 9)
                if (manager.cutscene == true && howMany > 5 && howMany <= 10)
                {
                    prof1.enabled = false;
                    prof2.enabled = false;
                    prof3.enabled = false;
                    cou1.enabled = true;
                    counselorOffice.enabled = true;
                }
            if (manager.cutscene == true && howMany >= 11)
            {
                prof1.enabled = false;
                prof2.enabled = false;
                prof3.enabled = true;
                cou1.enabled = false;
                counselorOffice.enabled = false;
            }
        }

        if (GameManager.currentLevel == 3)
        {
            if (manager.cutscene == true)
            {
                howMany++;
                print(howMany);
                print("Current level: " + GameManager.currentLevel);
                prof1.enabled = false;
                prof2.enabled = false;
                prof3.enabled = false;
                cou1.enabled = false;
                lounge.enabled = true;

            }

            if (howMany >= 4)
            {
                olivia.enabled = true;
            }
        }
        if (GameManager.currentLevel == 4)
        {
            if (manager.cutscene == true)
            {
                howMany++;
                print(howMany);
                print("Current level: " + GameManager.currentLevel);
                prof1.enabled = false;
                prof2.enabled = false;
                prof3.enabled = false;
                cou1.enabled = false;
                lounge.enabled = false;
                party.enabled = true;
                olivia.enabled = false;
            }
            if (howMany == 3)
            {
                daniel.enabled = true;
            }
            if (howMany == 4)
            {
                olivia.enabled = true;
                daniel.enabled = false;
            }
            if (howMany == 5)
            {
                olivia.enabled = true;
                daniel.enabled = true;
                jessabelle.enabled = true;
            }
            if (howMany == 6)
            {
                olivia.enabled = false;
                daniel.enabled = false;
                jessabelle.enabled = false;
            }
            if (howMany == 8)
            {
                jessabelle.enabled = true;
            }
            if (howMany >= 9)
            {
                jessabelle.enabled = false;
                cou1.enabled = true;
            }
            if (howMany == 16)
            {
                counselorOffice.enabled = true;
                party.enabled = false;
                cou1.enabled = true;
            }
            // if (GameManager.currentLevel <=)

        }




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
        cutsceneDialogueBox.SetActive(false);
        Debug.Log("End Conversation");
    }
}
