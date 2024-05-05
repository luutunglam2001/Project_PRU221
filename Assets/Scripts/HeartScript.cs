using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hearts;
    public GameObject gameOver;
    [SerializeField] private AudioSource audioGameOver;
    public static int life1 = 3;
    public static bool end = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (life1 > 3)
        {
            life1 = 3;
        }
        switch (life1)
        {
            
            case 3:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                break;
            case 2:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(false);
                break;
            case 1:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                break;
            case 0:
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                end = true;
                break;
        }
    }

    public void GameOver()
    {
        //life1 = 3;
        //gameOver.gameObject.SetActive(true);
        //audioGameOver.Play();
        //GameObject[] check1 = GameObject.FindGameObjectsWithTag("Checkpoint1");
        //foreach (GameObject obj in check1)
        //{
        //    CheckpointScript.nearestCheckpoint.position = obj.transform.position;
        //}
        //Debug.Log(CheckpointScript.nearestCheckpoint.position);
        //end = false;
    }

    //public void TurnOff()
    //{
    //    gameOver.gameObject.SetActive(false);
    //}
}
