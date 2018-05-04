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

    public GameObject[] listPrefabs;
    public int handCount = 0;
    GameObject handClone;
    Vector3 startCoords = new Vector3(800, 0, 0);
	List<GameObject> Lifes = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{
		Lifes.Add(GameObject.Find("Canvas/UI_Life_1"));
		Lifes.Add(GameObject.Find("Canvas/UI_Life_2"));
		Lifes.Add(GameObject.Find("Canvas/UI_Life_3"));

        //Start spawning hands
        StartCoroutine(spawnHand());
	}
	
	// Update is called once per frame
	void Update () {
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
        }
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
                handsInside[i].tag = "UsedHand";
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
                    handsInside[i].tag = "UsedHand";
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
		score += 10;
		UI_Score.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        handsInside[i].tag = "UsedHand";
    }
    void oneLifeLess()
    {
    	if (Lifes.Count > 1)
    	{
    		//Changes sprite of life
	    	int last = Lifes.Count - 1;
			Lifes[last].GetComponent<Image>().sprite = LifeDisabled;
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
            yield return new WaitForSeconds(2f);
            handClone.name = "hand" + handCount;
            handCount ++;

        }
    }
}

