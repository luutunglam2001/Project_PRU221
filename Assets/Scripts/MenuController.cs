using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject difficultyMenu;

    private void Start()
    {
        difficultyMenu.SetActive(false);
    }
    public void BackHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NewGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
        difficultyMenu.SetActive(true);
    }

    public void OnClickNormal()
    {
        difficultyMenu.SetActive(false);
        SettingsManager.Instance.diffSettings = 1;
        SceneManager.LoadScene("New Scene");
        HeartScript.end = false;
    }

    public void OnClickHard()
    {
        difficultyMenu.SetActive(false);
        SettingsManager.Instance.diffSettings = 2;
        SceneManager.LoadScene("New Scene");
        HeartScript.end = false;
    }

    public void OnClickVeryHardl()
    {
        difficultyMenu.SetActive(false);
        SettingsManager.Instance.diffSettings = 3;
        SceneManager.LoadScene("New Scene");

        HeartScript.end = false;
    }

    public void Construction()
    {
        SceneManager.LoadScene("Construction", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

}
