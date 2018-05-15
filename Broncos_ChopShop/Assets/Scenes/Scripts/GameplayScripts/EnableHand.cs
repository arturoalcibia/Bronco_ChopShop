using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class EnableHand : MonoBehaviour {

    [SerializeField] List<GameObject> handsInside = new List<GameObject>();
    [SerializeField] Text UI_Score;
    [SerializeField] GameObject hacha;
    int score = 0;

    [SerializeField] GameObject[] listPrefabs;
    int handCount = 0;
    GameObject handClone;
    Vector3 startCoords = new Vector3(1500, 0, 0);
	List<GameObject> Lifes = new List<GameObject>();

    [SerializeField] AudioClip goodSound, badSound;
    AudioSource audioSource;

    // Control of game 
    [SerializeField] float velocityIncrement = 2.0f;
    [SerializeField] int velocities = 5;
    [SerializeField] int scoreSteps = 60;
    int currentVelocity = 0;
    // Use this for initialization
    void Start () 
	{
		Lifes.Add(GameObject.Find("Canvas/UI_Life_1"));
		Lifes.Add(GameObject.Find("Canvas/UI_Life_2"));
		Lifes.Add(GameObject.Find("Canvas/UI_Life_3"));

        //Start spawning hands
        StartCoroutine(spawnHand());
        audioSource = GetComponent<AudioSource>();

        PlayerPrefs.SetFloat("VelocityIncrement", velocityIncrement);
        PlayerPrefs.SetInt("CurrentVelocity", currentVelocity);
    }
	
	// Update is called once per frame
	void Update () {

        bool downK = false;
        bool upK = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) && !upK)
        {
            // PASS
            Pass();
            upK = true;
        }

        
        if (Input.GetKeyDown(KeyCode.DownArrow) && !downK)
        {
            // SLICE
            Slice();
            downK = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
            upK = true;

        if (Input.GetKeyUp(KeyCode.DownArrow))
            downK = true;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //Current hand
		handsInside.Add(other.gameObject);
    }

    void OnTriggerExit2D (Collider2D other)
    {
        //Once the hand is outside the valid area to decide whether to slice or pass
        handsInside.Remove(other.gameObject);

        if (other.gameObject.tag != "UsedHand")
        {
            oneLifeLess();
            PlayAudioEffect(badSound);
        }
    }


    void PlayAudioEffect(AudioClip audioClip_)
    {
        float audioFx = PlayerPrefs.GetFloat("VolumenEffects");
        if (PlayerPrefs.GetInt("MuteEffects") == 1)
            audioFx = 0.0f;

        audioSource.PlayOneShot(audioClip_, audioFx);
    }

    public void Pass()
    {
    	if (handsInside.Count > 0)
    	{	
    		int i = handsInside.Count - 1;
			if (handsInside[i].tag == "BadHand")
			{
				validPlay(i);
                PlayAudioEffect(goodSound);
                handsInside[i].GetComponent<SpriteRenderer>().enabled = false;
            }
			else
			{
				Debug.Log("Incorrecto");
                handsInside[i].tag = "UsedHand";
				oneLifeLess();
                PlayAudioEffect(badSound);
            }
    	}
    }



    public void Slice()
    {
        if (score <=140)
            hacha.GetComponent<Animator>().SetBool("slice", true);
    	if (handsInside.Count > 0)
    	{	
    			int i = handsInside.Count - 1;
    			if (handsInside[i].tag != "GoodHand")
    			{
                    handsInside[i].tag = "UsedHand";
                oneLifeLess();
                    PlayAudioEffect(badSound);
                }
    			else
    			{
    				validPlay(i);
                    PlayAudioEffect(goodSound);
                }
    	}
    }


    void validPlay(int i)
    {
        //Dissapears Sprite Renderer and updates Score
        //handsInside[i].GetComponent<SpriteRenderer>().enabled = false;
        score += 10;

        if (score >= 150)
            handsInside[i].GetComponent<SpriteRenderer>().enabled = false;

        UI_Score.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        handsInside[i].tag = "UsedHand";
        

        if (currentVelocity < velocities)
        {
            currentVelocity = score / scoreSteps;
            scoreSteps = scoreSteps + 10;
            PlayerPrefs.SetInt("CurrentVelocity", currentVelocity);
        }  
    }
    void oneLifeLess()
    {
    	if (Lifes.Count > 1)
    	{
    		//Changes sprite of life
	    	int last = Lifes.Count - 1;
			Lifes[last].GetComponent<Image>().enabled = false;
			Lifes.Remove(Lifes[last]);
    	}
    	else
    	{
    		//GameOver
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("0124_Gam_Retry");
    	}
    }

    IEnumerator spawnHand()
    {
        while(true)
        {
            int prefab = Random.Range(0, 2);
            handClone= (GameObject)Instantiate(listPrefabs[prefab], startCoords, Quaternion.Euler(0, 0, 0));
            float timeWait = 2.0f;

            float customTime = timeWait - (timeWait * ((float)currentVelocity/(float)velocities) );

            if (customTime != 0)
                yield return new WaitForSeconds(customTime);
            else
                yield return null;
            handClone.name = "hand" + handCount;
            handCount ++;
        }
    }
}

