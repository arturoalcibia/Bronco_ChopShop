using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptionsCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
