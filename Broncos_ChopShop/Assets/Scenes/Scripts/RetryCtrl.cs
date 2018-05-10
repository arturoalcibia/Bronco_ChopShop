using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class RetryCtrl : MonoBehaviour {

    [SerializeField] Text scoreText;
    [SerializeField] int limitScores;

    public Transform canvas_transform;
	// Use this for initialization
	void Start () 
    {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        IsScoreHigher(scoreText.text + "|NaN");


	}
	
	// Update is called once per frame
	void Update () 
    {
		
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

    public void WriteScoreFile(List<string> newScores, string file)
    {

        File.WriteAllText(file, String.Empty);
        
        using(var tw = new StreamWriter(file, true))
        {
            foreach (string score in newScores)
            {
                //string scorePlayer = score.Split('|')[0];
                tw.WriteLine(score);
            }
        }
        

    }

    public List<string> ReadScoreFile(string file)
    {
        if (! File.Exists(file))
        {
            File.Create(file).Close();;
        }

        List<string> scores = new List<string>(File.ReadAllLines(file));
        return scores;
    }

    void IsScoreHigher(string newScore)
    {

        string path = Application.persistentDataPath;
        string file = path + "/" + "scoreBronco.txt";
        bool isScoreFull = false;
        bool isScoreEmpty = false;
        bool ishigher = false;
        int index = 99;

        List<string> scores = new List<string>(ReadScoreFile(file));

        if (scores.Count == limitScores)
            isScoreFull = true;
        if (scores.Count == 0)
            isScoreEmpty = true;
        
        int newScoreInt = Convert.ToInt32(newScore.Split('|')[0]);
        
        //In case scoreboard is empty
        if (isScoreEmpty == true)
        {
            scores.Add(newScore);
            ishigher = true;
            index = 0;
        }

        //scoreboard is halfway
        else if (isScoreFull == false && isScoreEmpty == false)
        {
            for(int i = 0; i < scores.Count; i++)
            {
                int scoreInt = Convert.ToInt32(scores[i].Split('|')[0]);

                if (newScoreInt > scoreInt || newScoreInt == scoreInt)
                    {
                        scores.Insert(i, newScore);
                        ishigher = true;
                        index = i;
                        break;
                    }
            }

            if (ishigher == false)
                {
                    index = scores.Count;
                    scores.Add(newScore);
                    ishigher = true;
                }
        }

        //In case scoreboard is full
        else
        {
            for(int i = 0; i < scores.Count; i++)
            {
                int scoreInt = Convert.ToInt32(scores[i].Split('|')[0]);

                if (newScoreInt > scoreInt || newScoreInt == scoreInt)
                {
                    scores.Insert(i, newScore);
                    scores.RemoveAt(scores.Count -1);
                    ishigher = true;
                    index = i;
                    break;
                }
            }
        }

        PopulateUI(scores, file, index);

        //if score needs to be displayed and stored
        if (ishigher == true)
        {
            WriteScoreFile(scores, file);
        }

    }

    void PopulateUI(List<string> newScores, string file, int indexPlayer)
    {
       List<string> scoresUI = new List<string>(newScores);

       int y = 175;

       for(int i = 0; i < scoresUI.Count; i++)
       {
            int no = 1 + i;
            CreateText(-75, y, no.ToString());
            CreateText(20, y, scoresUI[i].Split('|')[0]);

            if (indexPlayer != i)
                CreateText(165, y, scoresUI[i].Split('|')[1]);
            else
                CreateTextField(150, y);

            y -= 45;
       }
    }

    private void CreateTextField(int x, int y)
    
    {
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        GameObject uiInputField = DefaultControls.CreateInputField(uiResources);
        uiInputField.transform.SetParent(canvas_transform, false);
        uiInputField.transform.GetChild(0).GetComponent<Text>().font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        uiInputField.transform.GetChild(0).GetComponent<Text>().text = "Jugador";
        uiInputField.transform.GetChild(0).GetComponent<Text>().fontSize = 25;
        uiInputField.transform.GetChild(1).GetComponent<Text>().fontSize = 25;
        InputField input = uiInputField.GetComponent<InputField>();
        input.characterLimit = 3;

        RectTransform trans = uiInputField.GetComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);
        trans.sizeDelta = new Vector2 (150, 60);

        input.onValueChanged.AddListener(delegate {ValueChangeCheck(input); });


        //ColorBlock cb = input.colors;
        //cb.highlightedColor = new Color(0f, 0f, 0f, 0f);
        //input.colors = cb;

        Image image = uiInputField.GetComponent<Image>();
        image.color = new Color(0f, 0f, 0f, 0f);

        input.Select();

    }

    private void CreateText(int x, int y, string text_to_print)
    {
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        GameObject uiText = DefaultControls.CreateText(uiResources);
        uiText.transform.SetParent(canvas_transform, false);
        uiText.transform.GetComponent<Text>().font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        RectTransform trans = uiText.GetComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);

        Text text = uiText.GetComponent<Text>();
        text.fontSize = 25;
        text.text = text_to_print;


    }

    public void ValueChangeCheck(InputField input)
    {
        if (input.text.Length > 2)
        {
            input.enabled = false;
            editPlayerName(input.text);
        }
    }

    public void editPlayerName(string text)
    {
        string path = Application.persistentDataPath;
        string file = path + "/" + "scoreBronco.txt";

        List<string> scores = new List<string>(File.ReadAllLines(file));
        File.WriteAllText(file, String.Empty);
        using(var tw = new StreamWriter(file, true))
        {
            foreach (string score in scores)
            {
                if (score.Split('|')[1] == "NaN")
                {
                    string scorePlayer = score.Split('|')[0] + "|" + text;
                    tw.WriteLine(scorePlayer);
                }
                else
                {
                    tw.WriteLine(score);
                }
            }
        }
        

    }

}