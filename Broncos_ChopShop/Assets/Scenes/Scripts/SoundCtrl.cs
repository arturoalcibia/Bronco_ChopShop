using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundCtrl : MonoBehaviour {
    int mute = 0, muteEffects = 0;
    
    [SerializeField] public Toggle musicToggle;
    [SerializeField] public Slider musicSli;

    [SerializeField] public Toggle effectsToggle;
    [SerializeField] public Slider effectsSli;

    // Use this for initialization
    void Start () {
        mute = PlayerPrefs.GetInt("MuteMusic");
        muteEffects = PlayerPrefs.GetInt("MuteEffects");

        musicToggle.isOn = (mute != 0);
        effectsToggle.isOn = (muteEffects != 0);

        musicSli.value = PlayerPrefs.GetFloat("VolumenMusic");
        effectsSli.value = PlayerPrefs.GetFloat("VolumenEffects");
    }
	
	// Update is called once per frame
	void Update (){
        
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
