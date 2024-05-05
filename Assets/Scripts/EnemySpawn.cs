//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawn : MonoBehaviour
//{
//    GameObject[] enemyBases;
//    public GameObject enemyPrefab;
//    int count = 0;
//    int enemyBasesCount;
//    public int enemyNumber;
//    public float delayTime;

//    void Start()
//    {
//        enemyBases = GameObject.FindGameObjectsWithTag("EnemyBase");
//        enemyBasesCount = enemyBases.Length;
//        StartCoroutine(DelaySpawn());
//    }

//    IEnumerator DelaySpawn()
//    {
//        while (count < enemyNumber)
//        {
//            Instantiate(enemyPrefab, enemyBases[Random.Range(0, enemyBasesCount)].transform.position, Quaternion.identity);
//            count++;
//            yield return new WaitForSeconds(delayTime);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    GameObject[] enemyBases;

    public GameObject[] enemies;

    public GameObject enemyPrefab;
    GameObject instantiatePref;

    int count;
    int enemyBasesCount;
    public int enemyNumber;
    public float delayTime;

    int rng;

    void Start()
    {
        enemyBases = GameObject.FindGameObjectsWithTag("EnemyBase");
        enemyBasesCount = enemyBases.Length;
        print(SettingsManager.Instance.diffSettings);

        if (SettingsManager.Instance.diffSettings == 1)
        {
            enemyNumber = 10;
            delayTime = 10;
        }

        if (SettingsManager.Instance.diffSettings == 2)
        {
            enemyNumber = 15;
            delayTime = 8;
        }

        if (SettingsManager.Instance.diffSettings == 3)
        {
            enemyNumber = 15;
            delayTime = 8;
        }

        StartCoroutine(DelaySpawn());
    }

    IEnumerator DelaySpawn()
    {
        while (count < enemyNumber)
        {
            if (SettingsManager.Instance.diffSettings != 3)
            {
                print("1en");
                Instantiate(enemies[0], enemyBases[Random.Range(0, enemyBasesCount)].transform.position, Quaternion.identity);
            }
            else
            {
                print("2en");
                Instantiate(enemies[Random.Range(0, 2)], enemyBases[Random.Range(0, enemyBasesCount)].transform.position, Quaternion.identity);
            }
            count++;
            yield return new WaitForSeconds(delayTime);
        }
    }
}
