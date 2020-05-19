using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public Text nameText;
    public Text dialoqueText;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        animator.SetBool("isOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names) {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public bool DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return false;
        }

        string name = names.Dequeue();
        nameText.text = name;
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        return true;
    }

    IEnumerator TypeSentence(string sentence) {
        dialoqueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialoqueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("isOpen", false);
    }

}
