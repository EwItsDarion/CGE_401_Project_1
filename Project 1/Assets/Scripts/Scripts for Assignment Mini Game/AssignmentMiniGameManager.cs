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
    public GameObject assignmentMiniGameGroup, mainCollegeGroup;   //Groups
    public GameObject centralGamemanager;
   

   public void StartGame()
    {
        gameOver = false;

        successfulHits = missedHits = 0;
        //if it is the first level
        if (GameManager.currentLevel == 1)
        {

            maximumAssignments = 10;
            tutorialText1.enabled = true;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;

        }
        else
        {
            tutorialText1.enabled = false;
            tutorialText2.enabled = false;
            tutorialText3.enabled = false;
        }

        if (GameManager.currentLevel == 2)
            maximumAssignments = 15;
        else if (GameManager.currentLevel == 3)
            maximumAssignments = 20;
        else if (GameManager.currentLevel == 4)
            maximumAssignments = 25;

        assignmentsRemaining = maximumAssignments;

        //level complete text is not enabled
        levelCompleteText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Successful Assignments: " + successfulHits + "\nFailed Assignments: " + missedHits+ "\nRemaining Assignments: "+ assignmentsRemaining;

        if(GameManager.currentLevel == 1)
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
            FinishGame();

            if (!Input.GetKeyDown(KeyCode.Space))
            {
                levelCompleteText.text += "\nSuccessful strokes: " + PlayerControllerManager.successfulHitCount + "\nFailed Strokes: " +
                       PlayerControllerManager.failedHitCount + "\nAccuracy: " + average + " %" + "\nPress any key to continue";
            }
            else
            {
                assignmentMiniGameGroup.SetActive(false);
                centralGamemanager.GetComponent<GameManager>().moves--;
                mainCollegeGroup.SetActive(true);
            }

        }
    }

    void FinishGame()
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

        average = (successfulHits/maximumAssignments) * 100;
        centralGamemanager.GetComponent<GameManager>().academicScore += (int)average;
        if (gameWon)
        {
            levelCompleteText.text = "Level Complete!";
        }
        else
        {
            levelCompleteText.text = "Level Failed!";
        }



    }

}
