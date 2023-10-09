using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackAfterLevel : MonoBehaviour
{
    public GameManager GameManager;
    public Text dialogueText;
    public int playerScore;
    private float delay = 5f;

    private string[] negativeDialogues = {
        "You can do better!",
        "That was not your best performance.",
        "Try again and improve your score."
    };

    private string[] goodDialogues = {
        "Good job! You're getting there.",
        "Keep it up!",
        "You're on the right track."
    };

    private string[] greatDialogues = {
        "Outstanding! You're a superstar!",
        "Wow, you're amazing!",
        "You nailed it! Great job!"
    };

    private void Update()
    {
        playerScore = CalculatePlayerScore();


        if (GameManager.moves <= 0)
        {
            ShowFeedbackDialogue(playerScore);
            StartCoroutine(DisableTextBoxAfterDelay());
        }
        
    }
    IEnumerator DisableTextBoxAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        dialogueText.text = "";
    }
    private int CalculatePlayerScore()
    {

        int score = GameManager.academicScore + GameManager.socialScore;
        return score;
    }

    private void ShowFeedbackDialogue(int score)
    {
        
        if (score <= 2)
        {
            dialogueText.text = negativeDialogues[Random.Range(0, negativeDialogues.Length)];
        }
        else if (score >= 7)
        {
            dialogueText.text = greatDialogues[Random.Range(0, greatDialogues.Length)];
        }
        else
        {
            dialogueText.text = goodDialogues[Random.Range(0, goodDialogues.Length)];
        }
    }
}
