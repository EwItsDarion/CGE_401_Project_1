/*
 * Julian Avila
 * Project 1
 * Spawns random letters 
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
    private GameObject letter_Press;
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
            float delay = 1.5f;
            yield return new WaitForSeconds(delay);
        }

    }

    void SpawnRandomPrefab()
    {
        //pick a random animal
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        letter = prefabsToSpawn[prefabIndex];

        //Set spawn position by which letter they are
        if (letter.name == "Letter A")
        {
            letter_Press = GameObject.Find("Typing matcher (A)");
        }
        else if (letter.name == "Letter B")
        {
            letter_Press = GameObject.Find("Typing matcher (D)");
        }
        else
        {
            letter_Press = GameObject.Find("Typing matcher (B)");
        }
  
        spawnPos = new Vector3(letter_Press.transform.position.x-.10f, letter_Press.transform.position.y + 20, letter_Press.transform.position.z-.5f);

        //Instantiate/Create the animal in the generated spawn position
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);

       
    }
}
