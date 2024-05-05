using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }
    public int enemy = 0;
    public static bool trublood = true;
    public static bool phongthu = true;
    public int MaxRange { get; set; }
    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Nếu đụng vào brick thì destroy brick và đạn
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (enemy == 1)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (trublood && phongthu)
                {
                    print("mat tim");
                    HeartScript.life1 -= 1;
                }
                if (!phongthu)
                {
                    phongthu = true;
                }
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("bulletEnemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        if (enemy == 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }



        //Nếu đụng vào steel thì destroy đạn
        if (collision.gameObject.CompareTag("Steel"))
        {
            Destroy(gameObject);
        }

        //Nếu đụng vào boundary thì destroy đạn
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Base"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            HeartScript.end = true;
        }
    }

    private void DestroyAfterRange()
    {
        var currentPos = gameObject.transform.position;
        var initPos = Bullet.InitialPosition;
        switch (Bullet.Direction)
        {
            case Direction.Down:
                if (initPos.y - MaxRange >= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Up:
                if (initPos.y + MaxRange <= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}