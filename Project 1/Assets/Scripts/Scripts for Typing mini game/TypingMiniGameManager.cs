using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingMiniGameManager : MonoBehaviour
{
    private int maximumNumberofWords;
    public GameManager centralGameManager;
    public Text tutorialText1, tutorialText2, tutorialText3,tutorialText4,levelComplete;
    static public bool gameOver,gameWon,gameLoss;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        //if it is the first level, display tutorial text
        if (true)//(GameManager.level ==1)
        {
            tutorialText1.enabled = true;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;
            tutorialText4.enabled = false;
        }
        levelComplete.enabled = false;
    }

    // Update is called once per frame
    void Update()
    { 
        //If level is 1, go through tutorial
        if (PlayerControllerManager.successfulHitCount == 7 || PlayerControllerManager.failedHitCount == 7)
        {
            tutorialText4.enabled = true;
            tutorialText1.enabled = false;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;
        }
       else if (PlayerControllerManager.successfulHitCount == 5 || PlayerControllerManager.failedHitCount == 5)
        {
            tutorialText3.enabled = true;
            tutorialText1.enabled = false;
            tutorialText2.enabled = false;
            tutorialText4.enabled = false;
        }
        else if (PlayerControllerManager.successfulHitCount == 2 || PlayerControllerManager.failedHitCount == 2)
        {
            tutorialText2.enabled = true;
            tutorialText1.enabled = false;
            tutorialText3.enabled = false;
            tutorialText4.enabled = false;
        }

        if (PlayerControllerManager.successfulHitCount == 10 || PlayerControllerManager.failedHitCount == 10)
        {
            gameOver = true;
            if (PlayerControllerManager.successfulHitCount == 10)
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
        if(gameWon)
        {
            levelComplete.text = "Level Complete!";
        }
        else
        {
            levelComplete.text = "Level Failed!";
        }
        levelComplete.text += "\nSuccessful strokes: " + PlayerControllerManager.successfulHitCount + "\nFailed Strokes: " +
               PlayerControllerManager.failedHitCount;
    }
}
