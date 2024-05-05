using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private TankMover tankMover;
    public TankController tankController;
    public GameObject Anh7;
    private SpriteRenderer _renderer;
    public Vector3 newScale = new Vector3(1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        tankMover = FindObjectOfType<TankMover>();
        tankController = FindObjectOfType<TankController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Speed"))
        {
            Destroy(collision.gameObject);
            tankMover.speed = 2;
            yield return new WaitForSeconds(5f);
            tankMover.speed = 1;
        }
        if (collision.gameObject.CompareTag("Battu"))
        {
            Destroy(collision.gameObject);
            BulletController.trublood = false;
            yield return new WaitForSeconds(10f);
            BulletController.trublood = true;
        }
        if (collision.gameObject.CompareTag("PhongThu"))
        {
            if(collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
            BulletController.phongthu = false;
        }
        //if (collision.gameObject.CompareTag("Mark"))
        //{
        //    PointScript.win = true;
        //}
        //if (collision.gameObject.CompareTag("Heart"))
        //{
        //    HeartScript.life1 += 1;
        //}

    }
}
