/*Julian Avila
 * Project 1
 * Spawns objects in random coordinates according to a specific zone
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnZone;
    public GameObject objectBeingSpawned;
    private float upperBoundX, upperBoundY, lowerBoundX, lowerBoundY;
    // Start is called before the first frame update
    void Start()
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
        if (GameManager.currentLevel == 1) //level is 1 create a delay
            yield return new WaitForSeconds(2.0f);
        while (!AssignmentMiniGameManager.gameOver)
        { 
            Instantiate(objectBeingSpawned, new Vector3(Random.Range(lowerBoundX, upperBoundX), Random.Range(lowerBoundY, upperBoundY), -1), objectBeingSpawned.transform.rotation);

            if(GameManager.currentLevel==1)
            yield return new WaitForSeconds(5.0f);
            if (GameManager.currentLevel == 2)
                yield return new WaitForSeconds(4.0f);
            if (GameManager.currentLevel == 3)
                yield return new WaitForSeconds(3.0f);
            if (GameManager.currentLevel == 4)
                yield return new WaitForSeconds(2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
