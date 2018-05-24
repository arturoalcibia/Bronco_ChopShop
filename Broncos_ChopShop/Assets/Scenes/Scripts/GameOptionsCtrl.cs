using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]

public class GameOptionsCtrl : MonoBehaviour {

    AudioSource audioSource;
    //[SerializeField] AudioClip soundtrack;
    [SerializeField] AudioClip fxAudio;

    private void Awake()
    {
        /*
        GameObject[] oldMusic = GameObject.FindGameObjectsWithTag("BgMusic");
        if (oldMusic.Length != 0)
            for (int i = 0; i < oldMusic.Length; i++)
                Destroy(oldMusic[i]);
        */
    }

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.loop = true;

        float musicVolume = PlayerPrefs.GetFloat("VolumenMusic");
    
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
            musicVolume = 0.0f;

        //audioSource.PlayOneShot(soundtrack, musicVolume);
        //soundtrack.volume = musicVolume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadInspection()
    {
        SceneManager.LoadScene("0123_Gam_GamePlay");
    }

    public void LoadPractrice()
    {
        SceneManager.LoadScene("0123_Gam_GamePlay");
    }

    public void LoadWelcome()
    {
        SceneManager.LoadScene("0100_Welcome");
    }

    public void BtnButtonSound()
    {
        float audioFx = PlayerPrefs.GetFloat("VolumenEffects");
        if (PlayerPrefs.GetInt("MuteEffects") == 1)
            audioFx = 0.0f;

        audioSource.PlayOneShot(fxAudio, audioFx);
    }

}
