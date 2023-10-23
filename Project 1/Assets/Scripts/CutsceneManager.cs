using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Text dialogueText;
    private string[] dialogueMessages;
    private int currentMessageIndex = 0;
    public bool isDialogueActive = false;
    public CutsceneController_OpeningScene cutsceneControllerScript;
    public bool isDialogueDone = false;

    void Start()
    {
        // Initialize your dialogue messages here
        dialogueMessages = new string[]
        {
            "MOM: Here we are sweetie. This place will be your new home for the next couple of years. Are you nervous?",
            "PLAYER: A little, Mom. It's a big step.",
            "DAD: You're going to do great kiddo. Just remember to work hard and have fun.",
            "MOM(teary-eyed): We're going to miss you so much hun. You know you can call us anytime right? I want a call from you every night, no, every hour!",
            "PLAYER: I know mom, I promise I'll call you guys often.",
            "DAD(tear-eyed): It seems like just yesterday we were sending you off to kindergarten. You're growing up so fast.",
            "PLAYER: Thank you guys for always being there for me. I promise I'll make both of you proud.",
            "PLAYER: This is the next chapter of my life. I'm nervous about so many things: Making friends, keeping my grades up.. But I'm ready to have a great first year!"
        };

        // Show the first message
        ShowNextMessage();
    }

    void Update()
    {
        // Check for user input to advance the dialogue
        if (Input.GetMouseButtonDown(0) && isDialogueActive == true)
        {
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        if (currentMessageIndex < dialogueMessages.Length)
        {
            dialogueText.text = dialogueMessages[currentMessageIndex];
            currentMessageIndex++;
        }
        else
        {
            // All messages have been displayed
            dialogueText.text = "";
            cutsceneControllerScript.dialogueCanvas.SetActive(false);
            isDialogueDone = true;

        }
    }
}
