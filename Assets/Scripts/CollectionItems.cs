using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionItems : MonoBehaviour {
    private bool haveGlass = false;
    private bool haveWood = false;
    private bool haveJar = false;
    private bool haveEmptyBottle = false;

    public Image glassImage;
    public Image woodImage;
    public Image jarImage;
    public Image emptyBottleImage;

    void Start() {
        glassImage.enabled = false;
        woodImage.enabled = false;
        jarImage.enabled = false;
        emptyBottleImage.enabled = false;
    }

    void Update() {
        if (haveGlass) {
            glassImage.enabled = true;
        }

        if (haveWood) {
            woodImage.enabled = true;
        }

        if (haveJar) {
            jarImage.enabled = true;
        }

        if (haveEmptyBottle) {
            emptyBottleImage.enabled = true;
        }
    }

    public bool getGlass() {
        return this.haveGlass;
    }

    public bool getWood() {
        return this.haveWood;
    }

    public bool getJar() {
        return this.haveJar;
    }

    public bool getEmptyBottle() {
        return this.haveEmptyBottle;
    }

    public bool getAllTrue() { 
        if (getGlass() && getWood() && getJar() && getEmptyBottle()) {
            return true;
        }
        return false;
    }

    public void setGlass(bool haveGlass) {
        this.haveGlass = haveGlass;
    }

    public void setWood(bool haveWood) {
        this.haveWood = haveWood;
    }

    public void setJar(bool haveJar) {
        this.haveJar = haveJar;
    }

    public void setEmptyBottle(bool haveEmptyBottle) {
        this.haveEmptyBottle = haveEmptyBottle;
    }
}
