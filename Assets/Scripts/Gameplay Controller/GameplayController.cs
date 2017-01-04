using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class GameplayController : MonoBehaviour
{
    public static int Scene;
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject endGamePanel;

    [SerializeField]
    private Button resumeGame;

    [SerializeField]
    private Button resumeEndGame;

    [SerializeField]
    private GameObject levelPanel;

    public static int s_score = 0;
    public static int player = 3;
    public static int level = 1;
    public int timelevel = 200;

    public Text Score;
    public Text Level;
    public Text Player;

    public Text ScoreEnd;
    public Text ScoreEnd_Max;
    public Text LevelEnd;



    void Update()
    {
        timelevel--;
        loadLevelPanel();

        if (s_score >= PlayerPrefs.GetInt("ScoreMax"))
        {
            PlayerPrefs.SetInt("ScoreMax", s_score);
            PlayerPrefs.SetInt("LevelMax", level);
            PlayerPrefs.SetString("Time", DateTime.Now.ToString());
            PlayerPrefs.Save();
        }

        Score.text = s_score.ToString();
        Player.text = player.ToString();
        Level.text = "Level " + level.ToString();

        ScoreEnd.text = "Score: " + s_score.ToString();
        ScoreEnd_Max.text = "Max Score: " + PlayerPrefs.GetInt("ScoreMax").ToString();
        LevelEnd.text = "Level: " + level.ToString();

        if (player <= 0)
            PlayerDied();
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        player = 3;
        s_score = 0;
        timelevel = 200;
        level = 1;
        Time.timeScale = 1f;
        Application.LoadLevel(18);
        loadLevelPanel();
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        endGamePanel.SetActive(true);
        resumeEndGame.onClick.RemoveAllListeners();
        resumeEndGame.onClick.AddListener(() => RestartGame());
    }

    public void loadLevelPanel()
    {
        if(timelevel > 0)
        {
            Time.timeScale = 0f;
            levelPanel.SetActive(true);
        }
        else
        {
            timelevel = 0;
            Time.timeScale = 1f;
            levelPanel.SetActive(false);
        }
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainMenu");
    }
 
    public void LoadNextLevel(int Scene)
    {
        Application.LoadLevel(Scene);
    }
}
