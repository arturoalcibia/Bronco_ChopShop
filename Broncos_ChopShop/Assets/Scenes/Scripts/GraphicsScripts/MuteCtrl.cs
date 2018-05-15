using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteCtrl : MonoBehaviour {

    [SerializeField] AudioSource soundtrack;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MuteUpdate()
    {
        bool mute = !this.gameObject.GetComponent<Toggle>().isOn;
        int val = 0;
        if (mute)
            val = 1;
            
        PlayerPrefs.SetInt("MuteMusic", val);
        PlayerPrefs.SetInt("MuteEffects", val);

        AudioSource AudioCtrl = GameObject.Find("Gameplay_ctrl").GetComponent<AudioSource>();
        if (mute)
        {
            AudioCtrl.volume = 0.0f;
            soundtrack.volume = 0.0f;
        }
        else
        {
            float vol = PlayerPrefs.GetFloat("VolumenMusic");
            AudioCtrl.volume = vol;
            soundtrack.volume = vol;
        }
    }
}
