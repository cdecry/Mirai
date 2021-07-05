using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Input.GetMouseButton(0) && UserInterface.disableClickMovement == false)
        {
            SetTargetPosition();
            mouseMovement = true;

        }

        //Debug.Log(targetPosition.x - GameManager.players[Client.instance.myId].transform.position.x);
        if (Input.GetKey(KeyCode.UpArrow) || (Math.Abs(targetPosition.x - GameManager.players[Client.instance.myId].transform.position.x)) < 0.2 && (Math.Abs(targetPosition.y - GameManager.players[Client.instance.myId].transform.position.y)) < 0.2)
        {
            mouseMovement = false;
        }

        /*if (EventSystem.current.currentSelectedGameObject.name == "inventoryButton")
        {
            mouseMovement = false;
            Debug.Log("nope");
        }*/


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
    }
}