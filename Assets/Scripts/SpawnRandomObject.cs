using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    public GameObject[] objectToSpawn; // Game object xuat hien ngau nhien

    //public int numberOfSpawns = 10; // So lan xuat hien
    public GameObject parent;
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;
    public float checkRadius = 0.1f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while(true)
        {
            // Cu 3s thi lai xuat hien 1 lan
            yield return new WaitForSeconds(5f);
            
            while (true)
            {
                Vector3 randomPositionWithinBounds = new Vector3(
                Random.Range(targetObject1.transform.position.x, targetObject3.transform.position.x),
                Random.Range(targetObject2.transform.position.y, targetObject4.transform.position.y)
                );
                // Ki?m tra xem có va ch?m v?i các game object khác không
                Collider2D collision = Physics2D.OverlapCircle(randomPositionWithinBounds, checkRadius);
                bool hasCollision = true;
                if (collision != null )
                {
                    hasCollision = false;
                }
                if (hasCollision)
                {
                    GameObject objectToSpawn1;
                    objectToSpawn1 = objectToSpawn[Random.Range(0,objectToSpawn.Length)];
                    GameObject spawnedObject = Instantiate(objectToSpawn1, randomPositionWithinBounds, Quaternion.identity);
                    spawnedObject.transform.SetParent(parent.transform);
                    break;
                }
            }
            
        }
    }

}
