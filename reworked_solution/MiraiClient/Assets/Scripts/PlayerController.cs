using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPosition;
    public static bool mouseMovement, xMouseMovement, yMouseMovement;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        mouseMovement = false;
        xMouseMovement = false;
        yMouseMovement = false;
    }

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
            mouseMovement = true;
            if (Math.Abs(targetPosition.x - GameManager.players[Client.instance.myId].transform.position.x) > 0)
            {
                xMouseMovement = true;
            }
            if (Math.Abs(targetPosition.y - GameManager.players[Client.instance.myId].transform.position.y) > 0)
            {
                yMouseMovement = true;
            }

        }

        //Debug.Log(targetPosition.x - GameManager.players[Client.instance.myId].transform.position.x);
        if (Input.GetKey(KeyCode.UpArrow) || (Math.Abs(targetPosition.x - GameManager.players[Client.instance.myId].transform.position.x)) < 0.7 && (Math.Abs(targetPosition.y - GameManager.players[Client.instance.myId].transform.position.y)) < 0.7)
        {
            mouseMovement = false;
        }
        if (Math.Abs(targetPosition.x - GameManager.players[Client.instance.myId].transform.position.x) < 0.7)
        {
            xMouseMovement = false;
        }
        if (Math.Abs(targetPosition.y - GameManager.players[Client.instance.myId].transform.position.y) < 0.7)
        {
            yMouseMovement = false;
        }


        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.UpArrow),
            Input.GetKey(KeyCode.DownArrow),
            Input.GetKey(KeyCode.LeftArrow),
            Input.GetKey(KeyCode.RightArrow),
        };

        ClientSend.PlayerMovement(_inputs, targetPosition, GameManager.players[Client.instance.myId].transform.position, mouseMovement, xMouseMovement, yMouseMovement);
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //send over
        //isMoving = true;
    }
}