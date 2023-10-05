using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkillCheck;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public bool inZone;
    public bool locked = false;
    public GameObject pressEPrompt;
    public GameObject continuePrompt;
    public GameObject skillCheck;

    private GameObject NPC;
    public DialogueManager dialogueManager;
    private bool triggeredDialogue;

    public GameManager manager;


    public float speed = 5f;

    void Start() {
        inZone = false;
        
    }


    // Update is called once per frame
    void Update()
    {

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
            pressEPrompt.SetActive(false);
            locked = true;
        }

        if (locked) {
            if (skillCheck.GetComponent<SkillCheck>().stopped) { 
                //continuePrompt.SetActive(true);

                if (!triggeredDialogue) { 
                    NPC.GetComponent<DialogueTrigger>().TriggerDialogue(skillCheck.GetComponent<SkillCheck>().stopZone.ToString());
                    triggeredDialogue = true;
                
                }
                if (dialogueManager.empty) {
                    manager.moves--;
                    //continuePrompt.SetActive(false);
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
            pressEPrompt.SetActive(true);
            NPC = other.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPCZone"))
        {
            inZone = false;
            pressEPrompt.SetActive(false);
            NPC = null;
        }
    }

}
