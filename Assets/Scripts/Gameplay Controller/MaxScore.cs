using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour {

    public Text TextMaxScore;
    public Text TextTime;
    public Text TextMaxLevel;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        TextMaxScore.text = "Score: " + PlayerPrefs.GetInt("ScoreMax").ToString();
        TextTime.text = "Time: " + PlayerPrefs.GetString("Time").ToString();
        TextMaxLevel.text = "Level: " + PlayerPrefs.GetInt("LevelMax").ToString();
    }
}
