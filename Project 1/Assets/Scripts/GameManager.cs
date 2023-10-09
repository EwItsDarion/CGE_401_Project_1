using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject TypingGameGroup;
    public GameObject AssignmentGameGroup;
    public GameObject CollegeSceneGroup;
    public TypingMiniGameManager typingManager;
    public AssignmentMiniGameManager assignmentManager;


    public static int currentLevel;
    public int academicScore, socialScore;
    public int moves;
    public int maxLevel;

    public bool gameOver;
    public bool won;

    public Text scoreText;
    public Text scoreText2;
    public Text levelText;
    public GameObject[] NPCS;

    public GameObject tutorialElements;
    public GameObject Player;
    public Slider timerBar;
    private DialogueTrigger CutsceneManager;
    public DialogueManager dialogueManager;
    private bool scenetriggered;
    public bool cutscene;



    
    // Start is called before the first frame update
    void Awake()
    {
        gameOver = false;
        won = false;
        socialScore =academicScore = 0;
        currentLevel = 1;
        moves = 4;
        CutsceneManager = gameObject.GetComponent<DialogueTrigger>();
        scenetriggered = false;
        cutscene = true;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText2.text = "Academic Score: " + academicScore;

        levelText.text = "Level: " + currentLevel;

/*        if (cutscene) {
            tutorialElements.SetActive(false);
            Player.SetActive(false);

            if (!scenetriggered) {
                CutsceneManager.TriggerDialogue("Cutscene" + currentLevel);
                scenetriggered= true;
            }
            if (dialogueManager.empty) {
                if (currentLevel == 1) { 
                    tutorialElements.SetActive(true);
                }
                Player.SetActive(true);
                cutscene = false;
            }
        }*/

        timerBar.value = moves;

        scoreText.text = "Social Score: " + socialScore;

        if (moves <= 0) {
            moves = 4;
            currentLevel++;
            if (currentLevel <= 4) { 
                cutscene = true;
                scenetriggered = false;
            }

            if (currentLevel > maxLevel) {
                gameOver = true;

                if (academicScore > 10000 && socialScore > 15) { 
                    scoreText.text = "You Win!\nPress R to restart";
                }
                else
                {
                    scoreText.text = "You Lost!\nPress R to restart";
                }
                if(Input.GetKeyDown(KeyCode.R)) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                }


                foreach (var NPC in NPCS)
                {
                    NPC.GetComponent<BoxCollider2D>().enabled = true;
                }
            }

            /*gameOver = true;
            if (score >= 5) //Commented out until we finish leveling system
            { // win condition
                
            }
            else {
                
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }*/
        }

    }
}
