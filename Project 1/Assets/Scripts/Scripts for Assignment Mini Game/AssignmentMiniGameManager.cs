/*Julian Avila
 * Project 1
 * Manages assignment mini game and tutorial system
 */

using System;
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
    public GameObject centralGamemanager, assignmentSpawnManager;
    private static int levelOfDifficulty = 1;

    // Start is called before the first frame update
    public void StartGame()
    {
        gameOver = false;

        successfulHits = missedHits = 0;
        //if it is the first level
        if (levelOfDifficulty == 1)
        {

         
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

        //Increase assignments 
        maximumAssignments = levelOfDifficulty * 5;

        assignmentsRemaining = maximumAssignments;

        assignmentSpawnManager.GetComponent<SpawnManager>().StartSpawn();

       

        //level complete text is not enabled
        levelCompleteText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Successful Assignments: " + successfulHits + "\nFailed Assignments: " + missedHits+ "\nRemaining Assignments: "+ assignmentsRemaining;

        if(levelOfDifficulty == 1)
        {
            if (successfulHits == 4 || missedHits == 4)
            {
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText3.enabled = true;
            }
            if (successfulHits == 2 || missedHits == 2)
            {
                tutorialText1.enabled = false;
                tutorialText2.enabled = true;
                tutorialText3.enabled = false;
            }

        }

        if (assignmentsRemaining == 0)
        {
            gameOver = true;
            FinishGame();

            if (!Input.GetKeyDown(KeyCode.Space))
            {
                levelCompleteText.text += "\nSuccessful assignments: " + successfulHits + "\nFailed assignments: " +
                     missedHits + "\nAccuracy: " + average + " %" + "\nPress space to continue";
            }
            else
            {
                assignmentMiniGameGroup.SetActive(false);
                centralGamemanager.GetComponent<GameManager>().moves--;

                centralGamemanager.GetComponent<GameManager>().FindAverage((int)Math.Round(average)); //Add grade percentage to overall score

                if (gameWon)
                    levelOfDifficulty += 1;

                mainCollegeGroup.SetActive(true);
            }

        }
    }

    void FinishGame()
    {
      
            if (successfulHits > missedHits)
            {
                gameWon = true;
            }
            else
            {
                gameLoss = true;
            }

            levelCompleteText.enabled = true;

        average = (successfulHits/maximumAssignments) * 100;

        if (GameManager.currentLevel==1)
            {
                tutorialText1.enabled = false;
                tutorialText2.enabled = false;
                tutorialText3.enabled = false;
               
            }

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
