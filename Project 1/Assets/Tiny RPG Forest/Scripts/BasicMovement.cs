using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using static SkillCheck;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;

    //bools
    public bool inZone;
    public bool inTypingZone;
    public bool inClickingZone;
    public bool locked = false;
    private bool triggeredDialogue;

    //Prompts
    public GameObject pressEPromptConversation;
    public GameObject pressEPromptTypingGame;
    public GameObject pressSpacePrompt;
    public GameObject WASDtutorial;

    //Systems
    public GameObject skillCheck;
    private GameObject NPC;
    public DialogueManager dialogueManager;
    public GameManager manager;

    


    public float speed = 5f;

    void Start() {
        inZone = false;
        inTypingZone = false;
        inClickingZone = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) { 
            WASDtutorial.SetActive(false);
        }

        if (!locked)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime * speed;
            Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
            transform.position = transform.position + vertical * Time.deltaTime * speed;

        }
        

        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            skillCheck.SetActive(true);
            pressEPromptConversation.SetActive(false);
            pressSpacePrompt.SetActive(true);
            locked = true;
        }

        if (inTypingZone && Input.GetKeyDown(KeyCode.E))
        {
            manager.moves--;
            pressEPromptTypingGame.SetActive(false);
            manager.TypingGameGroup.SetActive(true);
            manager.CollegeSceneGroup.SetActive(false);

        }

        if (locked) {
            if (skillCheck.GetComponent<SkillCheck>().stopped) { 
                pressSpacePrompt.SetActive(false);
                if (!triggeredDialogue) { 
                    NPC.GetComponent<DialogueTrigger>().TriggerDialogue(skillCheck.GetComponent<SkillCheck>().stopZone.ToString() + GameManager.currentLevel.ToString());
                    triggeredDialogue = true;
                
                }
                if (dialogueManager.empty) {
                    manager.moves--;

                    skillCheck.GetComponent<SkillCheck>().Reset();
                    NPC.GetComponent<BoxCollider2D>().enabled= false;
                    locked = false;
                    triggeredDialogue = false;
                }            
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPCZone"))
        {
            inZone = true;
            pressEPromptConversation.SetActive(true);
            NPC = other.gameObject;
        }
        if (other.CompareTag("TypingMinigameActivator")) { 
            inTypingZone= true;
            pressEPromptTypingGame.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPCZone"))
        {
            inZone = false;
            pressEPromptConversation.SetActive(false);
            NPC = null;
        }
        if (other.CompareTag("TypingMinigameActivator"))
        {
            inTypingZone = false;
            pressEPromptTypingGame.SetActive(false);
        }
    }

}
