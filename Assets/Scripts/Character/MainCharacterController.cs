using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour {
    private MainCharacterRenderer isoRenderer;
    private GameObject enemy = null;
    private Vector2 currentPos;
    private Vector2 direction;
    private Vector2 inputVector;
    private Vector2 movement;
    private Vector2 newPos;
    private Rigidbody2D rbody;
    private CollectionItems collectionItems;

    private bool allItensCollected = false;
    private bool onExitPoint = false;
    private bool isAlive = true;
    private bool isTalking = false;
    private bool canTalk = false;
    private float speed;

    public Text talkToNpcText;
    public Text talkToNpcTextShadow;
    public DialogueManager dialogueManager;
    public Sound[] sounds;

    public float movementSpeed = 3f;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<MainCharacterRenderer>();

        foreach (Sound sound in sounds) {
            sound .source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }

    void Start() {
        talkToNpcText.enabled = false;
        talkToNpcTextShadow.enabled = false;
        collectionItems = GetComponent<CollectionItems>();
    }

    void Update() {
        if (!isTalking) {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }

        if (onExitPoint == true && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("EndGameScreen");
        }

        if (isAlive == false) {
            SceneManager.LoadScene("GameOverScreen");
        }

        if(canTalk && Input.GetKeyDown(KeyCode.Space)) {
            if(isTalking == false && enemy != null) {
                isTalking = true;
                enemy.GetComponent<DialogueTrigger>().TriggerDialogue(getRightItemFlagForCharacter());
            } else {
                bool moreText = dialogueManager.DisplayNextSentence();
                if (!moreText) {
                    isTalking = false;
                    setRightItemFlagFromCharacter();
                    if(allItensCollected && getEnemyName(enemy) == "Foxy") {
                        SceneManager.LoadScene("EndGameScreen");
                    }
                }
            }
        }
    }

    void FixedUpdate() {
        currentPos = rbody.position;
        inputVector = new Vector2(direction.x, direction.y);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        speed = movementSpeed;
        if (isTalking) {
            speed = 0;
        }

        movement = inputVector * speed;
        newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement, isTalking);
        rbody.MovePosition(newPos);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "enemy") {
            canTalk = true;
            enemy = other.gameObject;

            string npcName = enemy.gameObject.name.Replace("Collider", "");

            talkToNpcText.enabled = true;
            talkToNpcTextShadow.enabled = true;
            switch (npcName) {
                case "Scorpio":
                    play("scorpio");
                    break;
                case "Cracty":
                    play("cracty");
                    break;
                case "Cobra":
                    play("maracas");
                    break;
                case "Foxy":
                    play("feneco");
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        onExitPoint = false;
        talkToNpcText.enabled = false;
        talkToNpcTextShadow.enabled = false;
        canTalk = false;
        enemy = null;
    }

    public void play(string name) {
        Sound sound = Array.Find(sounds, sounds => sounds.name == name);
        sound.source.Play();
    }

    private string getEnemyName(GameObject enemy) {
        return enemy.transform.parent.gameObject.name;
    }

    private bool getRightItemFlagForCharacter() {
        bool flag = false;
        switch (getEnemyName(enemy)) {
            case "Scorpio":
                flag = collectionItems.getEmptyBottle();
                break;
            case "Cracty":
                flag = collectionItems.getGlass();
                break;
            case "Cobra":
                flag = collectionItems.getWood();
                break;
            case "Foxy":
                flag = collectionItems.getAllTrue();
                if (flag) {
                    allItensCollected = true;
                }
                break;
        }
        return flag;
    }

    private void setRightItemFlagFromCharacter() {
        switch (getEnemyName(enemy)) {
            case "Scorpio":
                collectionItems.setGlass(true);
                break;
            case "Cracty":
                if (collectionItems.getGlass()) {
                    collectionItems.setWood(true);
                    collectionItems.setEmptyBottle(true);
                }
                break;
            case "Cobra":
                if (collectionItems.getWood()) {
                    collectionItems.setJar(true);
                }
                break;
        }
    }

    public void setIsAlive(bool isAlive) {
        this.isAlive = isAlive;
    }
}
