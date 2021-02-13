using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header ("MAIN-MENU ELEMENTS")]
    public GameObject[] panels;
    public Button[] skins;

    public Material sample;

    public void Awake()
    {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
    }
    public void Begin()
    {
        Debug.Log("START");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Setting()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(true);
        Debug.Log("SETTING");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }
    public void Back()
    {
        panels[1].SetActive(false);
        panels[0].SetActive(true);
        Debug.Log("BACK TO MENU");
    }
    public void SkinChange(int skin)
    {
        PlayerPrefs.SetInt("SKIN", skin);
    }
}
