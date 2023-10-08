using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingMiniGameManager : MonoBehaviour
{
    static public int maximumNumberofLetters,lettersRemaining;
    private float average;
  
    public Text tutorialText1, tutorialText2, tutorialText3,tutorialText4,levelComplete,numberofLettersRemainingText;
    static public bool gameOver,gameWon,gameLoss;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        //if it is the first level, display tutorial text

       
        if (GameManager.currentLevel == 1) // if level 1
        {
            tutorialText1.enabled = true;
           
            LetterController.speed = 3;
        }
        else
        {
            tutorialText1.enabled = false;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;
            tutorialText4.enabled = false;
        }

        if(GameManager.currentLevel == 2)
        {
            LetterController.speed = 4;
        }
        else if (GameManager.currentLevel == 3)
        {
            LetterController.speed = 5;
        }
        else if (GameManager.currentLevel == 4)
        {
            LetterController.speed = 6;
        }

        maximumNumberofLetters = 10;
        lettersRemaining = maximumNumberofLetters;
     

        levelComplete.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        numberofLettersRemainingText.text = "Number of hits: " + PlayerControllerManager.successfulHitCount +
           "\nNumber of Misses: " + PlayerControllerManager.failedHitCount +
           "\nNumber of letters remaining: " + lettersRemaining;

        //If level is 1, go through tutorial
        if (GameManager.currentLevel == 1)
        {
            if (PlayerControllerManager.successfulHitCount == 7 || PlayerControllerManager.failedHitCount == 7)
            {
                tutorialText4.enabled = true;
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText3.enabled = false;
            }
            if (PlayerControllerManager.successfulHitCount == 5 || PlayerControllerManager.failedHitCount == 5)
            {
                tutorialText3.enabled = true;
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText4.enabled = false;
            }
            if (PlayerControllerManager.successfulHitCount == 2 || PlayerControllerManager.failedHitCount == 2)
            {
                tutorialText2.enabled = true;
                tutorialText1.enabled = false;
                tutorialText3.enabled = false;
                tutorialText4.enabled = false;
            }
        }


        if (lettersRemaining==0)
        {
            gameOver = true;
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
        }




        if(gameOver==true)
        {
            DisplayScore();
            return;
            
        }

    }

    void DisplayScore()
    {
        average = (PlayerControllerManager.successfulHitCount / maximumNumberofLetters)*100;
        if(gameWon)
        {
            levelComplete.text = "Level Complete!";
        }
        else
        {
            levelComplete.text = "Level Failed!";
        }
        levelComplete.text += "\nSuccessful strokes: " + PlayerControllerManager.successfulHitCount + "\nFailed Strokes: " +
               PlayerControllerManager.failedHitCount + "\nAccuracy: " + average + " %";
    }
}
