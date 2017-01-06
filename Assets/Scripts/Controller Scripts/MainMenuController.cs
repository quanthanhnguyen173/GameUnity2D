using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private GameObject maxScorePanel;

    [SerializeField]
    private Button info;
    [SerializeField]
    private Button score;

    int scene;
    public void infoGame()
    {
        infoPanel.SetActive(true);
        info.onClick.RemoveAllListeners();
    }

    public void maxScoreGame()
    {
        maxScorePanel.SetActive(true);
        score.onClick.RemoveAllListeners();
    }

    //Load scene
    public void PlayGame()
    {
        GameplayController.level = 1;
        GameplayController.player = 5;
        GameplayController.s_score = 0;
        scene = Random.Range(1, 21);
        Application.LoadLevel(scene);
    }

    public void BackToMenu()
    {
        infoPanel.SetActive(false);
        maxScorePanel.SetActive(false);
    }
}
