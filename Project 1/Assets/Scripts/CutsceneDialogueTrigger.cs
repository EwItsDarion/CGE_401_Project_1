using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CutsceneDialogueTrigger : MonoBehaviour
{

    public List<Dialogue> dialogues;
/*    public Dialogue good;
    public Dialogue bad;
    public Dialogue great;
*/
    public void TriggerDialogue(int playerLevel) {
        var dialogue = dialogues.Find(x => x.requiredLevel == playerLevel);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
