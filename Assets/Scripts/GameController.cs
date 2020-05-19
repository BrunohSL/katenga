using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Slider timeSlider;

    public float totalTime = 5f;

    private GameObject playerObj;
    private MainCharacterController playerController;

    private float timeLeft;

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObj.GetComponent<MainCharacterController>();

        timeLeft = totalTime;
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        timeSlider.value = timeLeft;

        if (timeLeft <= 0) {
            playerController.setIsAlive(false);
        }
    }
}
