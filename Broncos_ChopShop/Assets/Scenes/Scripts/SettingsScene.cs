using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSound()
    {
        SceneManager.LoadScene("0111_Set_Sound");
    }

    public void LoadKidMode()
    {
        SceneManager.LoadScene("0112_Set_KidMode");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("0113_Set_Credits");
    }

    public void LoadWelcome()
    {
        SceneManager.LoadScene("0100_Welcome");
    }

}
