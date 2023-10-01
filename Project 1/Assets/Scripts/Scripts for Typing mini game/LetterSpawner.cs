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
    private Vector3 spawnPos;
    private GameObject letter;

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

        letter = prefabsToSpawn[prefabIndex];

        //Set spawn position by which letter they are
        if ( letter.name == "Letter A")
            spawnPos = new Vector3(7.11f, 10.387f, -3.47f);
        else if (letter.name == "Letter D")
            spawnPos = new Vector3(9.47f, 10.468f, -3.47f);
        else
            spawnPos = new Vector3(8.25f, 10.37f, -3.47f);

        //Instantiate/Create the animal in the generated spawn position
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
