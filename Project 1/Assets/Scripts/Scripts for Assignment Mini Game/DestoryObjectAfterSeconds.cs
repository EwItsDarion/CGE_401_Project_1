﻿/*Julian Avila
 * Project 1
 * Destroys the object after some time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObjectAfterSeconds : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyObject()
    {
        while (AssignmentMiniGameManager.assignmentsRemaining !=0)
        {

          yield return new WaitForSeconds(6/AssignmentMiniGameManager.levelOfDifficulty);

            if (AssignmentMiniGameManager.pause == false)
            {
                Destroy(gameObject);
                AssignmentMiniGameManager.missedHits++;
                AssignmentMiniGameManager.assignmentsRemaining--;
            }

        }
    }

}
