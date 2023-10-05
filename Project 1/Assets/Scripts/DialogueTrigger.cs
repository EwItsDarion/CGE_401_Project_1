using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public List<Dialogue> dialogues;
/*    public Dialogue good;
    public Dialogue bad;
    public Dialogue great;
*/
    public void TriggerDialogue(string tag) {
        var dialogue = dialogues.Find(x => x.zone == tag);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
