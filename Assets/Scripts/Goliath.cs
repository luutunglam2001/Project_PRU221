using DefaultNamespace;
using Entity;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Goliath : MonoBehaviour
{
    public float enemyMS = 1f;
    public float boxCastExtraHeight = 0.01f;
    GameObject playerBase;
    public LayerMask wall;
    BoxCollider2D boxCollider2D;
    Direction direction;

    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    private enum MoveDirection
    {
        Left, Right
    }

    private MoveDirection moveDirection;

    void Start()
    {
        playerBase = GameObject.FindWithTag("Base");
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        direction = Direction.Left;
        moveDirection = MoveDirection.Left;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase)
        {
            if (!HasWallAhead())
            {
                if (transform.position.y != playerBase.transform.position.y)
                {
                    direction = Direction.Down;
                    Forward();
                }
            }
            if (HasWallAhead())
            {
                if (moveDirection == MoveDirection.Right)
                {
                    direction = Direction.Right;
                }
                if (moveDirection == MoveDirection.Left)
                {
                    direction = Direction.Left;
                }

                switch (moveDirection)
                {
                    case MoveDirection.Left:
                        if (HasWallLeft())
                        {
                            moveDirection = MoveDirection.Right;
                        }
                        else
                        {
                            GoToTheLeft();
                        }
                        break;

                    case MoveDirection.Right:
                        if (HasWallRight())
                        {
                            moveDirection = MoveDirection.Left;
                        }
                        else
                        {
                            GoToTheRight();
                        }
                        break;
                }
            }


            if (transform.position.y == playerBase.transform.position.y)
            {
                GoTowardsBase();
            }

            spriteRenderer.sprite = direction switch
            {
                Direction.Down => tankDown,
                Direction.Left => tankLeft,
                Direction.Right => tankRight,
                _ => spriteRenderer.sprite
            };
        }
    }

    bool HasWallAhead()
    {
        //Color color;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, boxCastExtraHeight, wall);
        //if (raycastHit)
        //{
        //    color = Color.red;
        //}
        //else
        //{
        //    color = Color.green;
        //}
        //Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + boxCastExtraHeight), color);
        //Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + boxCastExtraHeight), color);
        return raycastHit;
    }

    bool HasWallLeft()
    {
        //Color color;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.left, boxCastExtraHeight, wall);
        //if (raycastHit)
        //{
        //    color = Color.red;
        //}
        //else
        //{
        //    color = Color.green;
        //}
        //Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(0, boxCollider2D.bounds.extents.y), Vector2.left * (boxCollider2D.bounds.extents.x + boxCastExtraHeight), color);
        //Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(0, boxCollider2D.bounds.extents.y), Vector2.left * (boxCollider2D.bounds.extents.x + boxCastExtraHeight), color);
        return raycastHit;
    }

    bool HasWallRight()
    {
        //Color color;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.right, boxCastExtraHeight, wall);
        //if (raycastHit)
        //{
        //    color = Color.red;
        //}
        //else
        //{
        //    color = Color.green;
        //}
        //Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(0, boxCollider2D.bounds.extents.y), Vector2.right * (boxCollider2D.bounds.extents.x + boxCastExtraHeight), color);
        //Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(0, boxCollider2D.bounds.extents.y), Vector2.right * (boxCollider2D.bounds.extents.x + boxCastExtraHeight), color);
        return raycastHit;
    }

    void Forward()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, playerBase.transform.position.y), enemyMS * Time.deltaTime);
    }

    void GoToTheLeft()
    {
        transform.position += Vector3.left * enemyMS * Time.deltaTime;
    }

    void GoToTheRight()
    {
        transform.position += Vector3.right * enemyMS * Time.deltaTime;
    }

    void GoTowardsBase()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerBase.transform.position.x, transform.position.y), enemyMS * Time.deltaTime);
        if (EnemyXPositionToBase() >= 0)
        {
            direction = Direction.Left;
        }
        else
        {
            direction = Direction.Right;
        }
    }

    float EnemyXPositionToBase()
    {
        return transform.position.x - playerBase.transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Brick") || collision.gameObject.CompareTag("Steel"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Base"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            HeartScript.end = true;
        }
    }
}
