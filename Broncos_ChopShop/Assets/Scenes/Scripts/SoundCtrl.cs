using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class SoundCtrl : MonoBehaviour {
    int mute = 0, muteEffects = 0;
    
    [SerializeField] Toggle musicToggle;
    [SerializeField] Slider musicSli;

    [SerializeField] Toggle effectsToggle;
    [SerializeField] Slider effectsSli;

    [SerializeField] AudioClip fxAudio;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        mute = PlayerPrefs.GetInt("MuteMusic");
        muteEffects = PlayerPrefs.GetInt("MuteEffects");

        musicToggle.isOn = (mute != 0);
        effectsToggle.isOn = (muteEffects != 0);

        musicSli.value = PlayerPrefs.GetFloat("VolumenMusic");
        effectsSli.value = PlayerPrefs.GetFloat("VolumenEffects");

        float musicVolume = PlayerPrefs.GetFloat("VolumenMusic");
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
            musicVolume = 0.0f;
        GameObject AudioObject = GameObject.FindGameObjectWithTag("BgMusic");
        AudioObject.GetComponent<AudioSource>().volume = musicVolume;

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update (){
    }

    public void UpdateMusicLeves()
    {

        UpdateGlobalSettings();
        float musicVolume = PlayerPrefs.GetFloat("VolumenMusic");
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
            musicVolume = 0.0f;
        GameObject AudioObject = GameObject.FindGameObjectWithTag("BgMusic");
        AudioObject.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void UpdateFxLevels()
    {
        UpdateGlobalSettings();
        BtnButtonSound();
    }

    public void BtnButtonSound()
    {
        float audioFx = PlayerPrefs.GetFloat("VolumenEffects");
        if (PlayerPrefs.GetInt("MuteEffects") == 1)
            audioFx = 0.0f;

        audioSource.PlayOneShot(fxAudio, audioFx);
    }

    void UpdateGlobalSettings()
    {
        if (musicToggle.isOn)
            PlayerPrefs.SetInt("MuteMusic", 1);
        else
            PlayerPrefs.SetInt("MuteMusic", 0);

        PlayerPrefs.SetFloat("VolumenMusic", musicSli.value);

        // ----------------------------------------------
        if (effectsToggle.isOn)
            PlayerPrefs.SetInt("MuteEffects", 1);
        else
            PlayerPrefs.SetInt("MuteEffects", 0);

        PlayerPrefs.SetFloat("VolumenEffects", effectsSli.value);
    }

    public void LoadSettings()
    {
        if (musicToggle.isOn)
            PlayerPrefs.SetInt("MuteMusic", 1);
        else
            PlayerPrefs.SetInt("MuteMusic", 0);

        PlayerPrefs.SetFloat("VolumenMusic", musicSli.value);

        // ----------------------------------------------
        if (effectsToggle.isOn)
            PlayerPrefs.SetInt("MuteEffects", 1);
        else
            PlayerPrefs.SetInt("MuteEffects", 0);

        PlayerPrefs.SetFloat("VolumenEffects", effectsSli.value);


        SceneManager.LoadScene("0110_Settings");
        //Debug.Log(musicSli.value.ToString() + " Perro");
    }
}
