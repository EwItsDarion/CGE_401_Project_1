using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class CutsceneController_OpeningScene : MonoBehaviour
{
    public Transform player;

    public Text nameText;
    public Text dialogueText;
    public float moveSpeed = 2f;
    public Vector3 dialogueTriggerPosition; // Use Vector3 for the trigger position
    public GameObject dialogueCanvas;
    public CutsceneManager cutsceneScript;
    public LevelChangerScript levelChangerScript;


    void Update()
    {
        if (cutsceneScript.isDialogueDone == true)
        {
            levelChangerScript.FadeToLevel(2);
            levelChangerScript.OnFadeComplete();
            
            print("FADING IS COMPLETE");
        }
    }
    public bool IsCutsceneActive()
    {
        return Vector3.Distance(player.position, dialogueTriggerPosition) > 2f;
    }

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // Move characters to starting positions
        Vector3 initialPlayerPosition = player.position;
      

        // Calculate the destination position for the player
        Vector3 playerDestination = initialPlayerPosition + Vector3.up * 4.5f;

        // Start moving the player
        while (Vector3.Distance(player.position, playerDestination) > 0.1f)
        {
            player.position = Vector3.MoveTowards(player.position, playerDestination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Set the player's position to the exact destination
        player.position = playerDestination;

        // Trigger the dialogue system when reaching the dialogue trigger position
        if (Vector3.Distance(player.position, dialogueTriggerPosition) < 2f)
        {
            // Find the GameObject with the name "CutsceneManager"
            GameObject cutsceneManager = GameObject.Find("CutsceneManager");

            
                
            cutsceneManager.SetActive(true);
            dialogueCanvas.SetActive(true);
            cutsceneScript.isDialogueActive = true;
            Debug.Log("Player position: " + player.position);
            Debug.Log("Trigger pos: " + dialogueTriggerPosition);
           

 
        }
    }
}
