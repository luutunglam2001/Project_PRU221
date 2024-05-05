using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject mainMenu;

    Dictionary<int, GameObject> cursors = new Dictionary<int, GameObject>();

    public GameObject cursor1;
    public GameObject cursor2;

    int cursor = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);

        cursor1.SetActive(false);
        cursor2.SetActive(false);

        cursors.Add(1, cursor1);
        cursors.Add(2, cursor2);
    }

    void Update()
    {
        if (HeartScript.end)
        {
            mainMenu.SetActive(true);
        }
        if (mainMenu.activeSelf)
        {
            OnCursorControl();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cursor == 1)
                {
                    //SceneManager.LoadScene("1Player");
                    mainMenu.SetActive(false);
                    HeartScript.end = false;
                    SceneManager.LoadScene("New Scene");
                }
                if (cursor == 2)
                {
                    mainMenu.SetActive(false);
                    HeartScript.end = false;
                    SceneManager.LoadScene("StartGame");
                }
            }
        }    
    }

    void OnCursorControl()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (cursor != 0)
            {
                cursors[cursor].SetActive(false);
            }
            cursor++;
            if (cursor >= 3)
            {
                cursor = 1;
            }
            cursors[cursor].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (cursor != 3)
            {
                cursors[cursor].SetActive(false);
            }
            cursors[cursor].SetActive(false);
            cursor--;
            if (cursor <= 0)
            {
                cursor = 2;
            }
            cursors[cursor].SetActive(true);
        }
    }
}