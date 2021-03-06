﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (!PlayerPrefs.HasKey("Score"))
            PlayerPrefs.SetInt("Score", 0);

        if (!PlayerPrefs.HasKey("VolumenMusic"))
            PlayerPrefs.SetFloat("VolumenMusic", 0.50f);

        if (!PlayerPrefs.HasKey("MuteMusic"))
            PlayerPrefs.SetInt("MuteMusic", 0);

        if (!PlayerPrefs.HasKey("VolumenEffects"))
            PlayerPrefs.SetFloat("VolumenEffects", 0.50f);

        if (!PlayerPrefs.HasKey("MuteEffects"))
            PlayerPrefs.SetInt("MuteEffects", 0);

        if (!PlayerPrefs.HasKey("KidMode"))
            PlayerPrefs.SetInt("KidMode", 0);

        float musicVolume = PlayerPrefs.GetFloat("VolumenMusic");
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
            musicVolume = 0.0f;
        GameObject AudioObject = GameObject.FindGameObjectWithTag("BgMusic");
        AudioObject.GetComponent<AudioSource>().volume = musicVolume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSettings()
    {
        SceneManager.LoadScene("0110_Settings");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("0120_GameOptions");
    }
}
