using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;
    //public int level; //eventual level control variable?
    public int moves;

    public bool gameOver;
    public bool won;

    public Text scoreText;



    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
        //level = 1;
        moves = 4;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (moves <= 0) {
            gameOver = true;
            if (score >= 5)
            { // win condition
                scoreText.text = "You Win!\nPress R to restart";
            }
            else {
                scoreText.text = "You Lost!\nPress R to restart";
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
