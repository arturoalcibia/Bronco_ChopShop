using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidModeUI : MonoBehaviour {
    Toggle configKid;
	// Use this for initialization
	void Start () {
        bool KidM = PlayerPrefs.GetInt("KidMode") == 1;
        this.gameObject.GetComponent<Toggle>().isOn = configKid;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateKidMode()
    {
        bool KiDM = this.gameObject.GetComponent<Toggle>().isOn;
        int i = 0;
        if (KiDM)
            i = 1;
        PlayerPrefs.SetInt("KidMode", i);
    }
}
