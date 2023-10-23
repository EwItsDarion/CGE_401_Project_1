using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MoveSystem moveSystem;
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
    public GameObject cutscenePanelBox;
    public GameObject Player;
    public Slider timerBar;
    public Slider academicBar;
    public Slider socialBar;
    private DialogueTrigger CutsceneManager;
    public DialogueManager dialogueManager;
    private bool scenetriggered;
    public bool cutscene;


    private int numberOfAssigments;
    private int totalScore;
    private int average;
    // Start is called before the first frame update
    void Awake()
    {
        gameOver = false;
        won = false;
        socialScore = academicScore = 0;
        currentLevel = 1;
        moves = 4;
        CutsceneManager = gameObject.GetComponent<DialogueTrigger>();
        scenetriggered = false;
        cutscene = false;
        numberOfAssigments = 0;
        totalScore = 0;
        average = 0;
    }

    // Update is called once per frame
    void Update()
    {
        socialBar.value = socialScore;
        academicBar.value = academicScore;
        scoreText2.text = "Academic Score: " + academicScore;

        levelText.text = "Level: " + currentLevel;

        if (cutscene) {
            tutorialElements.SetActive(false);
            cutscenePanelBox.SetActive(true);
            Player.SetActive(false);


            if (!scenetriggered) {
                CutsceneManager.TriggerDialogue("Cutscene" + currentLevel);
                scenetriggered = true;
            }
            if (dialogueManager.empty) {
                if (currentLevel == 1) { 
                    tutorialElements.SetActive(true);
                }
                Player.SetActive(true);
                cutscene = false;
                cutscenePanelBox.SetActive(false);
                dialogueManager.howMany = 0;
            }
        }

        //timerBar.value = moves;

        scoreText.text = "Social Score: " + socialScore;

        if (moves <= 0) {
            moves = 4;
            moveSystem.ResetMoves();
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

    public void FindAverage(int newGrade)
    {
        numberOfAssigments++;

        totalScore += newGrade;

        average = totalScore / numberOfAssigments;

        academicScore = average;
    }

}
