using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Transform player;
    public Transform parents;
    public float moveSpeed = 2f;
    public Transform dialogueTrigger; // The point where the dialogue should start.

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // Move characters to starting positions
        Vector3 initialPlayerPosition = player.position;
        Vector3 initialParentsPosition = parents.position;

        // Calculate the destination position for the player
        Vector3 playerDestination = initialPlayerPosition + Vector3.up * 4f;

        // Move the player and parents
        while (player.position != playerDestination)
        {
            player.position = Vector3.MoveTowards(player.position, playerDestination, moveSpeed * Time.deltaTime);
            parents.position = Vector3.MoveTowards(parents.position, initialParentsPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Trigger the dialogue system
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>(); // Find your DialogueManager in the scene
        if (dialogueManager != null)
        {
            // Dialogue for cutscene
            string[] lines = new string[]
            {
                "1#Parent: Hello!",
                "1#Player: Hi there!"
                // Add the lines
            };

            Dialogue dialogue = new Dialogue
            {
                sentences = new System.Collections.Generic.List<string>(lines)
            };

            dialogueManager.StartDialogue(dialogue);
        }

        // Wait for the conversation to end
        while (!dialogueManager.empty)
        {
            yield return null;
        }

        // Move characters back to their original positions
        player.position = initialPlayerPosition;
        parents.position = initialParentsPosition;

        // May need ot dispose of game objects like the car and parents
        // gameObject.SetActive(false); // or Destroy(gameObject);
    }
}