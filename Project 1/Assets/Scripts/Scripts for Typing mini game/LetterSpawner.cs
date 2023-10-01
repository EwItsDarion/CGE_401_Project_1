/*
 * Julian Avila
 * Prototype 2
 * Spawns random animals in a random position
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSpawner : MonoBehaviour
{
    //Set this array references in the inspector
    public GameObject[] prefabsToSpawn;
    private float rightBound = 14, leftBound = -14, SpawnPosZ = 20;
    private Vector3 spawnPos;
  

    void Start()
    {
        StartCoroutine(SpawnRandomPrefabwithCoroutine());
    }

    IEnumerator SpawnRandomPrefabwithCoroutine()
    {
        //add a 3 second delay before first spawning objects
        yield return new WaitForSeconds(3f);

        while (true)
        {
            SpawnRandomPrefab();
            float randomDelay = Random.Range(0.8f, 2.0f);
            yield return new WaitForSeconds(randomDelay);
        }

    }

    void SpawnRandomPrefab()
    {
        //pick a random animal
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        //Generate spawn position
        spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, SpawnPosZ);

        //Instantiate/Create the animal in the generated spawn position
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
