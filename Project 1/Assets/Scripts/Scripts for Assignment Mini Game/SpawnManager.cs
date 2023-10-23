/*Julian Avila
 * Project 1
 * Spawns objects in random coordinates according to a specific zone
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    public GameObject spawnZone;
    public GameObject objectBeingSpawned;
    private float upperBoundX, upperBoundY, lowerBoundX, lowerBoundY;
    public Text countDownText;
    // Start is called before the first frame update
    public void StartSpawn()
    {
        //get spawn boundaries
        lowerBoundX = spawnZone.GetComponent<Transform>().position.x;
        upperBoundX = spawnZone.GetComponent<Transform>().position.x + ((spawnZone.GetComponent<Collider>().bounds.size.x));
        


        lowerBoundY = spawnZone.GetComponent<Transform>().position.y - ((spawnZone.GetComponent<Collider>().bounds.size.y));
        upperBoundY = spawnZone.GetComponent<Transform>().position.y;


        StartCoroutine(SpawnObjectsInRandomPosition());

    }

    IEnumerator SpawnObjectsInRandomPosition()
    {
        if (AssignmentMiniGameManager.levelOfDifficulty==1)
            yield return new WaitForSeconds(5f);
      
            //add a 3 second delay before first spawning objects
            countDownText.text = "3...";
            yield return new WaitForSeconds(1f);
            countDownText.text = "2...";
            yield return new WaitForSeconds(1f);
            countDownText.text = "1...";
            yield return new WaitForSeconds(1f);
            countDownText.text = "GO!";
            yield return new WaitForSeconds(1f);
            countDownText.text = " ";
        


        while (!AssignmentMiniGameManager.gameOver || AssignmentMiniGameManager.assignmentsRemaining != 0)
        {

                if(AssignmentMiniGameManager.pause==false)
                Instantiate(objectBeingSpawned, new Vector3(Random.Range(lowerBoundX, upperBoundX), Random.Range(lowerBoundY, upperBoundY), -10), objectBeingSpawned.transform.rotation);

            yield return new WaitForSeconds((5-(.5f * AssignmentMiniGameManager.levelOfDifficulty)) +1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
