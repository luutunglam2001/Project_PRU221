using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1;

    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private IEnumerator OnTriggerEnter2D(Collider2D collision)
    //{
    //    //N?u ??ng vào brick thì destroy brick và ??n
    //    //if (collision.gameObject.CompareTag("Speed"))
    //    //{
    //    //    Destroy(collision.gameObject);
    //    //    speed = 2;
    //    //    yield return new WaitForSeconds(5f);
    //    //    speed = 1;
    //    //}
    //}

    public Vector3 Move(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= speed*Time.deltaTime;
                break;
            case Direction.Left:
                currentPos.x -= speed*Time.deltaTime;
                break;
            case Direction.Right:
                currentPos.x += speed*Time.deltaTime;
                break;
            case Direction.Up:
                currentPos.y += speed*Time.deltaTime;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;
    }
}