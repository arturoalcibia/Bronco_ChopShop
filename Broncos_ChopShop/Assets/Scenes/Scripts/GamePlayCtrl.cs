using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrl : MonoBehaviour {

    [SerializeField] GameObject audioBackground;
    AudioSource ctrlMusic;
    float musicVolume = 0.0f;

    // Use this for initialization
    void Start ()
    {
        ctrlMusic = audioBackground.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("VolumenMusic");

        if (PlayerPrefs.GetInt("MuteMusic") == 1)
            musicVolume = 0.0f;

        ctrlMusic.volume = musicVolume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
