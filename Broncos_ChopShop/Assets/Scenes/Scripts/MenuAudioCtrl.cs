using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioCtrl : MonoBehaviour {
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BgMusic");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        float VolumenM = 1.0f;
        if (PlayerPrefs.HasKey("VolumenMusic"))
            VolumenM = PlayerPrefs.GetFloat("VolumenMusic");

        if (PlayerPrefs.HasKey("MuteMusic"))
        {
            if (PlayerPrefs.GetInt("MuteMusic") == 1)
                VolumenM = 0.0f;
        }

        AudioSource audioCtrl = this.gameObject.GetComponent<AudioSource>();
        audioCtrl.volume = VolumenM;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
