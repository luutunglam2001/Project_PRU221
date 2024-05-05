using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePointer();
    }

    void MovePointer()
    {
        var currentPos = transform.position;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentPos.x -= 0.16f;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentPos.x += 0.16f;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentPos.y += 0.16f;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentPos.y -= 0.16f;
        }
        transform.position = currentPos;
    }
}
