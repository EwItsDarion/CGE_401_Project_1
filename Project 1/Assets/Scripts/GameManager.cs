using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;
    public static int currentLevel;
    public int moves;
    public int maxLevel;

    public bool gameOver;
    public bool won;

    public Text scoreText;
    public GameObject[] NPCS;

    public GameObject tutorialElements;
    public GameObject Player;
    private DialogueTrigger cutscenes;
    public DialogueManager dialogueManager;
    private bool scenetriggered;



    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
        currentLevel = 1;
        moves = 4;
        cutscenes = gameObject.GetComponent<DialogueTrigger>();
        scenetriggered = false;
    }

    // Update is called once per frame
    void Update()
    {

/*        if (!scenetriggered) {
            bool sceneEnded = false;
            tutorialElements.SetActive(false);
            Player.SetActive(false);
            cutscenes.TriggerDialogue("Cutscene" + currentLevel);
            scenetriggered = true;

                if (dialogueManager.empty) {
                
                    //reactivate tutorial elements on first level only
                    if (currentLevel == 1) { 
                        tutorialElements.SetActive(true);

                    //allow player movement
                    Player.SetActive(true);
                    sceneEnded = true;

             
        }*/
        


        scoreText.text = "Score: " + score;

        if (moves <= 0) {
            moves = 4;
            currentLevel++;

            foreach (var NPC in NPCS) {
                NPC.GetComponent<BoxCollider2D>().enabled = true;
            }

            /*gameOver = true;
            if (score >= 5) //Commented out until we finish leveling system
            { // win condition
                scoreText.text = "You Win!\nPress R to restart";
            }
            else {
                scoreText.text = "You Lost!\nPress R to restart";
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }*/
        }

    }
}
