using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingMiniGameManager : MonoBehaviour
{
    static public int maximumNumberofLetters, lettersRemaining;
    private float average;

    public Text levelComplete, numberofLettersRemainingText;
    public GameObject tutorialPanel, tutorialGuide1,tutorialGuide2,tutorialGuide3,tutorialGuide4,tutorialGuide5,levelCompletePanel;
    static public bool gameOver, gameWon, gameLoss,letterCollidedWithTyper,pause,canPress;
    public GameObject typingMiniGameGroup, collegeSceneGroup;
    public GameObject centralGameManager;
    public GameObject letterSpawnManager;//get spawner
    private GameObject[] remainingLettersAfterFinish;
    public static int levelOfDifficulty = 1;
    public static float time, timeDelay;
    public AudioSource mainAudio;
    public AudioSource gameAudio;

    public void StartGame()
    {
        gameAudio.enabled = true;
        mainAudio.enabled = false;
        gameOver = false;
        levelComplete.enabled = false;
        levelCompletePanel.SetActive(false);



        //if it is the first level, display tutorial text
        if (levelOfDifficulty == 1) // if level 1
        {
            //tutorialText1.enabled = true;
            tutorialPanel.SetActive(true);
            tutorialGuide1.SetActive(true);
            tutorialGuide2.SetActive(false);
            tutorialGuide3.SetActive(false);
            tutorialGuide4.SetActive(false);
            tutorialGuide5.SetActive(false);



            time = 0f;
            timeDelay = 5f;
            canPress = false;
        }
        else
        {
            letterSpawnManager.GetComponent<LetterSpawner>().StartSpawn();
        }
        LetterController.speed = levelOfDifficulty+3;
        maximumNumberofLetters = 7*levelOfDifficulty; //set speed of letters


        lettersRemaining = maximumNumberofLetters;

        PlayerControllerManager.successfulHitCount = PlayerControllerManager.failedHitCount = 0;

       
    }

    // Update is called once per frame
    void Update()
    {

        //If level is 1, go through tutorial
        if (levelOfDifficulty == 1)
        {
            if(tutorialGuide1.activeInHierarchy==true&& Input.GetKeyDown(KeyCode.Space))
            {
                letterSpawnManager.GetComponent<LetterSpawner>().StartSpawn();
                tutorialGuide1.SetActive(false);
                tutorialPanel.SetActive(false);
                
            }

            if (letterCollidedWithTyper && lettersRemaining==maximumNumberofLetters && time <= timeDelay * 1) //If the letter has met with the keyboard typer, pause for a few seconds
            {
                tutorialGuide2.SetActive(true); //Instruct them what to do
                tutorialPanel.SetActive(true);
                LetterController.speed = 0;
                pause = true;

                time += 1f * Time.deltaTime;
               
            }
            else if (time>=timeDelay*1&& tutorialGuide2.activeInHierarchy==true) //If a certain amount of time has elapsed, allow the player to type the key/letter
            {
               
                tutorialGuide2.GetComponentInChildren<Text>().text = " \"..Type the following keys on your keyboard, A, S, and D, at the right time..\"" + "\n\n(Type the corresponding letter to continue)";
                tutorialGuide2.GetComponentInChildren<Text>().color = new Color(0, 0, 139);
                canPress = true;

                if (letterCollidedWithTyper==false)
                {
                    tutorialGuide2.SetActive(false);
                    tutorialPanel.SetActive(false);
                    LetterController.speed = levelOfDifficulty + 3;
                    pause = false;
                }
            }
           
            //For the rest of tutorial, the prompts will give advice to the student
            if(lettersRemaining==5 && time<timeDelay*2)
            {
                tutorialGuide3.SetActive(true);
                tutorialPanel.SetActive(true);
                LetterController.speed = 0;
                time += 1f * Time.deltaTime;
                pause = true;
                
            }
            else if (time >= timeDelay * 2)
            {
                tutorialGuide3.GetComponentInChildren<Text>().text = "(Press Space to continue)";
                tutorialGuide3.GetComponentInChildren<Text>().color = new Color(0, 0, 139);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialGuide3.SetActive(false);
                    tutorialPanel.SetActive(false);
                    LetterController.speed = levelOfDifficulty + 3;
                    pause = false;
                }
            }

            if (lettersRemaining == 3 && time < timeDelay*3)
            {
                tutorialGuide4.SetActive(true);
                tutorialGuide3.SetActive(false);
                tutorialPanel.SetActive(true);
                LetterController.speed = 0;
                time += 1f * Time.deltaTime;
                pause = true;
            }
            else if (time >= timeDelay * 3)
            {
                tutorialGuide4.GetComponentInChildren<Text>().text = "(Press Space to continue)";
                tutorialGuide4.GetComponentInChildren<Text>().color = new Color(0, 0, 139);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialGuide4.SetActive(false);
                    tutorialPanel.SetActive(false);
                    LetterController.speed = levelOfDifficulty + 3;
                    pause = false;
                }
            }


            if (lettersRemaining == 1 && time < (timeDelay*4)+2)
            {
                tutorialGuide5.SetActive(true);
                tutorialGuide3.SetActive(false);
                tutorialGuide4.SetActive(false);
                tutorialPanel.SetActive(true);
                LetterController.speed = 0;
                  time += 1f * Time.deltaTime;
                pause = true;
            }
            else if (time >= timeDelay * 4)
            {
                tutorialGuide5.GetComponentInChildren<Text>().text = "(Press Space to continue)";
                tutorialGuide5.GetComponentInChildren<Text>().color = new Color(0, 0, 139);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialGuide5.SetActive(false);
                    tutorialPanel.SetActive(false);
                    LetterController.speed = levelOfDifficulty + 3;
                    pause = false;
                }
            }

        }


        numberofLettersRemainingText.text = "Number of hits: " + PlayerControllerManager.successfulHitCount +
           "\nNumber of Misses: " + PlayerControllerManager.failedHitCount +
           "\nNumber of letters remaining: " + lettersRemaining;



       


        if (lettersRemaining == 0)
        {
            gameOver = true;
            FinishGame();
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                levelCompletePanel.SetActive(true);
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
        gameAudio.enabled = false;
        mainAudio.enabled = true;
        if (PlayerControllerManager.successfulHitCount > PlayerControllerManager.failedHitCount)
        {
            gameWon = true;
        }
        else
        {
            gameLoss = true;
        }

        levelComplete.enabled = true;

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
