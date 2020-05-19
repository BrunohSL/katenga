using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartStoryDialogManager : MonoBehaviour {
    public Text dialogueText;

    private Queue<string> sentences;
    private StartStoryDialogueTrigger trigger;

    void Start() {
        sentences = new Queue<string>();

        trigger = GetComponent<StartStoryDialogueTrigger>();
        trigger.triggerDialogue();
    }

    public void startDialogue(StartStoryDialog dialogue) {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            displayNextSentence();
        }
    }

    public void displayNextSentence() {
        if (sentences.Count == 0) {
            endOfDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator typeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void endOfDialogue() {
        SceneManager.LoadScene("Dryland");
    }
}
