using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class UIManager : MonoSingleton<UIManager>
{

    protected override void Init()
    {
        base.Init();
    }

    public GameObject UserInterface;

    private void Start()
    {
        //CameraController.Instance.Setup(() => PlayerInfo.Instance.playerPrefab.transform.position);
    }

    private void Update()
    {
        //UserInterface.transform.position = new Vector2(PlayerInfo.Instance.playerPrefab.transform.position.x + 2, PlayerInfo.Instance.playerPrefab.transform.position.y);
        var keyCode = "";
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyCode = "right";
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyCode = "left";
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            keyCode = "up";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            keyCode = "down";
        }

        if (keyCode != "")
        {
            MovePlayer movement = new MovePlayer
            {
                connectionID = Client.Instance.networkClient.connection.connectionId,
                keyPressed = keyCode,
            };
            movement.HandleMovement();
        }

    }

    public void Logout()
    {
        Debug.Log("Attempting to logout");
        //ClientScene.RemovePlayer(0);

        /*LogoutRequest request = new LogoutRequest
        {
            connectionID = Client.Instance.networkClient.connection.connectionId
        };

        request.HandleRequest();*/

        Client.Instance.networkClient.Disconnect();

        Debug.Log("Dropped from server");
        SceneManager.LoadScene("Main_Menu");

        //SceneManager.LoadScene("Main_Menu");


    }
}
