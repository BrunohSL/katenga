using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStoryDialogueTrigger : MonoBehaviour {
    public StartStoryDialog dialogue;

    public void triggerDialogue() {
        FindObjectOfType<StartStoryDialogManager>().startDialogue(dialogue);
    }
}
