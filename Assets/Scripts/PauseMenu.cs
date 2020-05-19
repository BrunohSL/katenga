using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;

    private CollectionItems collectionItems;

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (gameIsPaused) {
                resume();
                AudioListener.pause = false;
            } else {
                pause();
                AudioListener.pause = true;
            }
        }
    }

    public void resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void pause() {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}
