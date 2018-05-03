using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryCtrl : MonoBehaviour {

    [SerializeField] Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Retry()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("0123_Gam_GamePlay");
    }

    public void LoadBegin()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("0100_Welcome");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
