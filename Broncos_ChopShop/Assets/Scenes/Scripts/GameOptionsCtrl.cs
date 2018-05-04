using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class GameOptionsCtrl : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField] AudioClip soundtrack;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        float musicVolume = PlayerPrefs.GetFloat("VolumeMusic");

        /*
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
            musicVolume = 0.0f;
        */
        audioSource.PlayOneShot(soundtrack, 1.0f);
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
}
