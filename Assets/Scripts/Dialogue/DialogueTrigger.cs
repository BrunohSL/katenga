using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Dialogue dialogueRight;
    public Dialogue dialogueWrong;

    public void TriggerDialogue(bool hasItem) {
        Dialogue dialogue = dialogueWrong;
        if (hasItem) {
            dialogue = dialogueRight;
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
