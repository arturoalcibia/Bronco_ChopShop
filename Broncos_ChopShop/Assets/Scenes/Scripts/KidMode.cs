using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KidMode : MonoBehaviour {

    int kidMode = 0;
    [SerializeField] public Toggle effectsToggle;

    // Use this for initialization
    void Start () {
        kidMode = PlayerPrefs.GetInt("KidMode");
        effectsToggle.isOn = (kidMode == 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (effectsToggle.isOn)  kidMode = 1;
        else kidMode = 0;

        PlayerPrefs.SetInt("KidMode", kidMode) ;
	}

    public void LoadSettings() {
        SceneManager.LoadScene("0110_Settings");
    }
}
