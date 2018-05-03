using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnableHand : MonoBehaviour {

	public List<GameObject> handsInside = new List<GameObject>();
	public Text UI_Score;
	public int score = 0;

	public Sprite LifeEnabled;
	public Sprite LifeDisabled;

	public List<GameObject> Lifes = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{
		Lifes.Add(GameObject.Find("life_3"));
		Lifes.Add(GameObject.Find("life_2"));
		Lifes.Add(GameObject.Find("life_1"));
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D (Collider2D other)
    {
		handsInside.Add(other.gameObject);
    }

    void OnTriggerExit2D (Collider2D other)
    {
		handsInside.Remove(other.gameObject);
    }

    public void Pass()
    {
    	if (handsInside.Count > 0)
    	{	
    		int i = handsInside.Count - 1;
			if (handsInside[i].tag == "BadHand")
			{
				
				validPlay(i);
			}
			else
			{
				Debug.Log("Incorrecto");
				oneLifeLess();
			}
    	}
    }



    public void Slice()
    {
    	if (handsInside.Count > 0)
    	{	
    			int i = handsInside.Count - 1;
    			if (handsInside[i].tag != "GoodHand")
    			{
    				Debug.Log("Incorrecto");
    				oneLifeLess();
    			}

    			else
    			{
    				
    				validPlay(i);
    			}
    	}
    }

    void validPlay(int i)
    {
    	//Dissapears Sprite Renderer and updates Score
		handsInside[i].GetComponent<SpriteRenderer>().enabled = false;
		score ++;
		UI_Score.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
    void oneLifeLess()
    {
    	if (Lifes.Count > 1)
    	{
    		//Changes sprite of life
	    	int last = Lifes.Count - 1;
			Lifes[last].GetComponent<SpriteRenderer>().sprite = LifeDisabled;
			Lifes.Remove(Lifes[last]);
    	}
    	else
    	{
    		//GameOver
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("0124_Gam_Retry");
    	}
    }
}

