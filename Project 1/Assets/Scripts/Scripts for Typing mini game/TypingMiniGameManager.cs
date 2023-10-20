using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingMiniGameManager : MonoBehaviour
{
    static public int maximumNumberofLetters, lettersRemaining;
    private float average;

    public Text tutorialText1, tutorialText2, tutorialText3, tutorialText4, levelComplete, numberofLettersRemainingText;
    static public bool gameOver, gameWon, gameLoss;
    public GameObject typingMiniGameGroup, collegeSceneGroup;
    public GameObject centralGameManager;
    public GameObject letterSpawnManager;//get spawner
    private GameObject[] remainingLettersAfterFinish;
    private int levelOfDifficulty=1;
    // Start is called before the first frame update
    public void StartGame()
    {
        gameOver = false;

       

        tutorialText1.enabled = false;
        tutorialText2.enabled = false;
        tutorialText3.enabled = false;
        tutorialText4.enabled = false;

        

        //if it is the first level, display tutorial text
        if (levelOfDifficulty == 1) // if level 1
        {
            tutorialText1.enabled = true;
       
        }

        LetterController.speed = levelOfDifficulty;
        maximumNumberofLetters = 10+levelOfDifficulty; //set speed of letters

        letterSpawnManager.GetComponent<LetterSpawner>().StartSpawn();

        lettersRemaining = maximumNumberofLetters;

        PlayerControllerManager.successfulHitCount = PlayerControllerManager.failedHitCount = 0;

        levelComplete.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        numberofLettersRemainingText.text = "Number of hits: " + PlayerControllerManager.successfulHitCount +
           "\nNumber of Misses: " + PlayerControllerManager.failedHitCount +
           "\nNumber of letters remaining: " + lettersRemaining;



        //If level is 1, go through tutorial
        if (levelOfDifficulty == 1)
        {
            if (PlayerControllerManager.successfulHitCount == 4 || PlayerControllerManager.failedHitCount == 4)
            {
                tutorialText4.enabled = true;
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText3.enabled = false;
            }
            if (PlayerControllerManager.successfulHitCount == 2 || PlayerControllerManager.failedHitCount == 2)
            {
                tutorialText3.enabled = true;
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText4.enabled = false;
            }
            if (PlayerControllerManager.successfulHitCount == 1 || PlayerControllerManager.failedHitCount == 1)
            {
                tutorialText2.enabled = true;
                tutorialText1.enabled = false;
                tutorialText3.enabled = false;
                tutorialText4.enabled = false;
            }
        }


        if (lettersRemaining == 0)
        {
            gameOver = true;
            FinishGame();
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                levelComplete.text += "\nSuccessful strokes: " + PlayerControllerManager.successfulHitCount + "\nFailed Strokes: " +
                       PlayerControllerManager.failedHitCount + "\nAccuracy: " + average + " %" + "\n\nPress space to continue";
            }
            else
            {
                //remova all remaining letters
                remainingLettersAfterFinish = GameObject.FindGameObjectsWithTag("Letter");
                foreach (GameObject letter in remainingLettersAfterFinish)
                    Destroy(letter);
                typingMiniGameGroup.SetActive(false);

                centralGameManager.GetComponent<GameManager>().FindAverage((int)Math.Round(average)); //Add grade percentage to overall score

                //increase level of difficulty
                levelOfDifficulty++;

                centralGameManager.GetComponent<GameManager>().moves--;
                collegeSceneGroup.SetActive(true);
            }

            
        }

    
    }


    void FinishGame()
    {
        if (PlayerControllerManager.successfulHitCount > PlayerControllerManager.failedHitCount)
        {
            gameWon = true;
        }
        else
        {
            gameLoss = true;
        }

        levelComplete.enabled = true;
        tutorialText2.enabled = false;
        tutorialText1.enabled = false;
        tutorialText3.enabled = false;
        tutorialText4.enabled = false;



        average = (PlayerControllerManager.successfulHitCount / maximumNumberofLetters) * 100;

        if (gameWon)
        {
            levelComplete.text = "Level Complete!";
        }
        else
        {
            levelComplete.text = "Level Failed!";
        }

     

    }

}
