/*Julian Avila
 * Project 1
 * Manages assignment mini game and tutorial system
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AssignmentMiniGameManager : MonoBehaviour
{
    static public int maximumAssignments, assignmentsRemaining;
    static public float successfulHits, missedHits,average;
    public Text tutorialText1, tutorialText2, tutorialText3, ScoreText,levelCompleteText;
    static public bool gameOver, gameWon, gameLoss;
   

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        successfulHits = missedHits = 0;


        //if it is the first level
        if(true)//)GameManager.currentLevel==1)
        {
            tutorialText1.enabled = true;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;
            maximumAssignments = 10;
            assignmentsRemaining = maximumAssignments;
        }
        else
        {
            tutorialText1.enabled = false;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;
        }

        //level complete text is not enabled
        levelCompleteText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Successful Assignments: " + successfulHits + "\nFailed Assignments: " + missedHits+ "\nRemaining Assignments: "+ assignmentsRemaining;

        if(true)
        {
            if (successfulHits == 5 || missedHits == 5)
            {
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText3.enabled = true;
            }
            if (successfulHits == 3 || missedHits == 3)
            {
                tutorialText1.enabled = false;
                tutorialText2.enabled = true;
                tutorialText3.enabled = false;
            }

        }

        if (assignmentsRemaining == 0)
        {
            gameOver = true;
            if (successfulHits > missedHits)
            {
                gameWon = true;
            }
            else
            {
                gameLoss = true;
            }

            levelCompleteText.enabled = true;

            if (GameManager.currentLevel==1)
            {
                tutorialText2.enabled = false;
                tutorialText1.enabled = false;
                tutorialText3.enabled = false;
               
            }

            DisplayScore();
        }
    }

    void DisplayScore()
    {
        average = (successfulHits/maximumAssignments) * 100;
        if (gameWon)
        {
            levelCompleteText.text = "Level Complete!";
        }
        else
        {
            levelCompleteText.text = "Level Failed!";
        }
        levelCompleteText.text += "\nSuccessful strokes: " + successfulHits + "\nFailed Strokes: " +
               missedHits + "\nAccuracy: " + average + " %";
    }

}
