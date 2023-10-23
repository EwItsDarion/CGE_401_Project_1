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
    public Text /*tutorialText1, tutorialText2, tutorialText3*/ScoreText,levelCompleteText;
    public GameObject tutorialPanel, beginningTutorialGuide, tutorialGuide1,tutorialGuide2,tutorialGuide3,tutorialGuide4;
    static public bool gameOver, gameWon, gameLoss,objectDestroyed,pause,canClick;
    public GameObject assignmentMiniGameGroup, mainCollegeGroup;   //Groups
    public GameObject centralGamemanager, assignmentSpawnManager;
    public static int levelOfDifficulty = 1;
    public static float time, timeDelay;

    // Start is called before the first frame update
    public void StartGame()
    {
        gameOver = false;
        
        successfulHits = missedHits = 0;
        //if it is the first level
        if (levelOfDifficulty == 1)
        {
            tutorialPanel.SetActive(true);
            beginningTutorialGuide.SetActive(true);
            tutorialGuide1.SetActive(false);
            tutorialGuide2.SetActive(false);
            tutorialGuide3.SetActive(false);
            tutorialGuide4.SetActive(false);

            time = 0f;
            timeDelay = 5f;

            //tutorialText1.enabled = true;
            //tutorialText2.enabled = false;
            //tutorialText3.enabled = false;

        }
        else
        {

            assignmentSpawnManager.GetComponent<SpawnManager>().StartSpawn();
            tutorialPanel.SetActive(false);
            beginningTutorialGuide.SetActive(false);
            tutorialGuide1.SetActive(false);
            tutorialGuide2.SetActive(false);
            tutorialGuide3.SetActive(false);
            tutorialGuide4.SetActive(false);
            //tutorialText1.enabled = false;
            //tutorialText2.enabled = false;
            //tutorialText3.enabled = false;
        }

        //Increase assignments 
        maximumAssignments = levelOfDifficulty * 7;

        assignmentsRemaining = maximumAssignments;


       

        //level complete text is not enabled
        levelCompleteText.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Successful Assignments: " + successfulHits + "\nFailed Assignments: " + missedHits+ "\nRemaining Assignments: "+ assignmentsRemaining;

        if(levelOfDifficulty == 1)
        {

            if (beginningTutorialGuide.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Space))
            {
                assignmentSpawnManager.GetComponent<SpawnManager>().StartSpawn();
                beginningTutorialGuide.SetActive(false);
                tutorialPanel.SetActive(false);

            }

            if (GameObject.FindGameObjectWithTag("Assignment")!=null /*&& assignmentsRemaining==maximumAssignments*/ && time <= timeDelay * 1)
            {

                tutorialGuide1.SetActive(true);
                tutorialPanel.SetActive(true);
                time += 1f * Time.deltaTime;
                pause = true;

            }
            else if (time >= timeDelay * 1&&tutorialGuide1.activeInHierarchy == true)
            {
                tutorialGuide1.GetComponentInChildren<Text>().text = "(Click the assignment to continue)";
                tutorialGuide1.GetComponentInChildren<Text>().color = new Color(0, 0, 139);
                canClick = true;
                if (assignmentsRemaining<maximumAssignments)
                {
                    tutorialGuide1.SetActive(false);
                    tutorialPanel.SetActive(false);
                    pause = false;
                }
            }


            if (assignmentsRemaining == 4 && time < timeDelay * 2)
            {
                tutorialGuide2.SetActive(true);
                tutorialPanel.SetActive(true);
                time += 1f * Time.deltaTime;
                pause = true;

            }
            else if (tutorialGuide2.activeInHierarchy == true)
            {
                tutorialGuide2.GetComponentInChildren<Text>().text = "(Press Space to continue)";
                tutorialGuide2.GetComponentInChildren<Text>().color = new Color(0, 0, 139);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialGuide2.SetActive(false);
                    tutorialPanel.SetActive(false);
                    pause = false;
                }
            }

            if (assignmentsRemaining == 3 && time < timeDelay * 3)
            {
                tutorialGuide3.SetActive(true);
                tutorialPanel.SetActive(true);
                time += 1f * Time.deltaTime;
                pause = true;

            }
            else if (tutorialGuide3.activeInHierarchy == true)
            {
                tutorialGuide3.GetComponentInChildren<Text>().text = "(Press Space to continue)";
                tutorialGuide3.GetComponentInChildren<Text>().color = new Color(0, 0, 139);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialGuide3.SetActive(false);
                    tutorialPanel.SetActive(false);
                    pause = false;
                }
            }

            if (assignmentsRemaining == 1 && time < timeDelay * 4)
            {
                tutorialGuide4.SetActive(true);
                tutorialPanel.SetActive(true);
                time += 1f * Time.deltaTime;
                pause = true;

            }
            else if (tutorialGuide4.activeInHierarchy == true)
            {
                tutorialGuide4.GetComponentInChildren<Text>().text = "(Press Space to continue)";
                tutorialGuide4.GetComponentInChildren<Text>().color = new Color(0, 0, 139);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tutorialGuide4.SetActive(false);
                    tutorialPanel.SetActive(false);
                    pause = false;
                }
            }

          

            //if (successfulHits == 4 || missedHits == 4)
            //{
            //    tutorialText1.enabled = false;
            //    tutorialText2.enabled = false;
            //    tutorialText3.enabled = true;
            //}
            //if (successfulHits == 2 || missedHits == 2)
            //{
            //    tutorialText1.enabled = false;
            //    tutorialText2.enabled = true;
            //    tutorialText3.enabled = false;
            //}

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

                foreach(GameObject assignment in GameObject.FindGameObjectsWithTag("Assignment"))
                Destroy(assignment);

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
