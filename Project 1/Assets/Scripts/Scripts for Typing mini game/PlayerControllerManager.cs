using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControllerManager : MonoBehaviour
{

    private GameObject letter;
    public Material good, bad, normal,pressed;
    public bool successfulHit = false, failedHit = false;
    private bool pressedA, pressedD, pressedB;


    public Text computerText;
    private string[] randomWords;
    private int randomWordIndex;
    public int wordCount;
    static public float successfulHitCount=0, failedHitCount=0;
    // Start is called before the first frame update
    void Start()
    {
        wordCount = 0;
        //Asynchronous function that turns the keys back to their normal color after they have changed 
        InvokeRepeating("TurnToNormal", 0f, 1.5f);

        randomWords = new string[]{"The","Apple","Chicken","School","Happy"};
    }

    void Update()
    {
       
       
        wordCount = computerText.text.Split(' ').Length;

        //Refresh computer screen with a new page
        if (wordCount > 5)
            computerText.text = "";

        //if the player types the letter at the precise moment, then the key will turn a color green
        if (successfulHit)
            gameObject.GetComponent<Renderer>().material = good;
        //if the player misses the letter, then the key will turn a color red
        if (failedHit)
            gameObject.GetComponent<Renderer>().material = bad;
        //if the next letter has not touched the key, then by default it will be a color white
        if (successfulHit == false && failedHit == false)
            gameObject.GetComponent<Renderer>().material = normal;
    }

    void OnTriggerExit(Collider other)
    {
        //If the player misses typing a letter, then a failed hit occurs
        if (other.gameObject.CompareTag("Letter"))
            failedHit = true;
    }

    void OnTriggerStay(Collider other)
    {
        randomWordIndex = Random.Range(0, randomWords.Length);
        if (other.gameObject.CompareTag("Letter"))
        {
            //if matcher collides with a letter and the player types the letter, destroy the letter
            if (other.gameObject.name == "Letter A(Clone)")
            {
                if (Input.GetKey(KeyCode.A))
                {
                    computerText.text += randomWords[randomWordIndex] + " ";
                    Destroy(other.gameObject);
                    Debug.Log("Hit");
                    successfulHit = true;
                    //Increment successful hits
                    successfulHitCount++;
                    //Decrement number of letters remaining
                    TypingMiniGameManager.lettersRemaining--;
                }

            }
            else if (other.gameObject.name == "Letter B(Clone)")
            {
                if (Input.GetKey(KeyCode.B))
                {
                    computerText.text += randomWords[randomWordIndex] + " ";
                    Destroy(other.gameObject);
                    Debug.Log("Hit");
                    successfulHit = true;
                    successfulHitCount++;
                    TypingMiniGameManager.lettersRemaining--;
                }
            }

            else if (other.gameObject.name == "Letter D(Clone)")
            {
                if (Input.GetKey(KeyCode.D))
                {
                    computerText.text += randomWords[randomWordIndex] + " ";
                    Destroy(other.gameObject);
                    Debug.Log("Hit");
                    successfulHit = true;
                    successfulHitCount++;
                    TypingMiniGameManager.lettersRemaining--;
                }
            }
        }
    }


    void TurnToNormal()
    {
        if (successfulHit)
            successfulHit = false;
        

        if (failedHit)
            failedHit = false;
    }

}


