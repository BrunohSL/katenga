using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject soundControl;
    public Sprite audioOn;
    public Sprite audioOff;

    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.pause == true)
        {
            soundControl.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            soundControl.GetComponent<Image>().sprite = audioOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundControl()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            soundControl.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.pause = true;
            soundControl.GetComponent<Image>().sprite = audioOn;
        }
    }
}
