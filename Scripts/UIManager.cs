using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text score_txt;
    public Text coin_txt;
    public Text HighScore_txt;

    public Text performance_comment;
    public GameObject button_panel;
    public Button[] skins;

    private void Awake()
    {
        button_panel.SetActive(false);
        score_txt.text = 0.ToString();
        coin_txt.text = "COIN : " + 0;
        performance_comment.text = "";
        HighScore_txt.text = "HIGH-SCORE : " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    public void setScore(int score)
    {
        score_txt.text = score.ToString();
        PlayerPrefs.SetInt("Highscore", score);
    }
    public void setCoin(int coin)
    {
        coin_txt.text = "COIN : " + coin;
    }
    public void setComment(string comment)
    {
        performance_comment.text = comment;
    }
    public void restartStatus(bool restart)
    {
        if (restart)
        {
            button_panel.SetActive(true);
        }
    }
    public void Begin()
    {
        Debug.Log("START");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Back()
    {
        if(SceneManager.GetActiveScene().buildIndex > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
