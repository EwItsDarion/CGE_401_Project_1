using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    private float lowerBoundary;
    public static float speed;
    // Start is called before the first frame update
    void Start()
    {
        lowerBoundary = -4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(TypingMiniGameManager.gameOver == false)
        transform.Translate(Vector3.down *  Time.deltaTime * speed);

        //Player misses the letter
        if(transform.position.y<=lowerBoundary)
        {
            Destroy(gameObject);
            //Increment misses
            PlayerControllerManager.failedHitCount++;
            //Decrement number of letters remaining
            TypingMiniGameManager.lettersRemaining--;
        }

    }
}
