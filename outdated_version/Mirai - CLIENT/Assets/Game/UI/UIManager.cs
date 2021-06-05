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
    public double rightBound = 5;
    public double leftBound = -5;
    public double rightStop = 3.8;
    public double leftStop = -3.8;
    public bool camRight;
    public bool camLeft;

    private void Start()
    {
        //CameraController.Instance.Setup(() => PlayerInfo.Instance.playerPrefab.transform.position);
        camRight = false;
        camLeft = false;
        PlayerInfo.Instance.playerPrefab.transform.position = PlayerInfo.Instance.playerPrefab.transform.position;
    }

    private void Update()
    {

        PlayerInfo.Instance.playerLocation = SceneManager.GetActiveScene().name;

        //UserInterface.transform.position = new Vector2(PlayerInfo.Instance.playerPrefab.transform.position.x + 2, PlayerInfo.Instance.playerPrefab.transform.position.y);
        var keyCode = "";
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyCode = "right";
            //CameraController.CameraRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyCode = "left";
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            keyCode = "up";
            Debug.Log(PlayerInfo.Instance.playerLocation);
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

        /*
        if (PlayerInfo.Instance.playerPrefab.transform.position.x >= rightBound)
        {
            camRight = true;
            //rightBound += 50;
        }
        if (PlayerInfo.Instance.playerPrefab.transform.position.x <= leftBound)
        {
            camLeft = true;
        }

        if (camRight == true)
        {
            CameraController.CameraRight();
            if (CameraController.Instance.transform.position.x >= rightStop)
            {
                leftStop += 3.8;
                leftBound += 3.8;
                camRight = false;
                rightBound += 3.8;
                rightStop += 3.8;
            }
        }
        if (camLeft == true)
        {
            CameraController.CameraLeft();
            if (CameraController.Instance.transform.position.x <= leftStop)
            {
                rightStop -= 3.8;
                rightBound -= 3.8;
                camLeft = false;
                leftBound -= 3.8;
                leftStop -= 3.8;
            }
        }
        */
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
        Destroy(GameObject.Find("Player(Clone)"));
        SceneManager.LoadScene("Main_Menu");

        //SceneManager.LoadScene("Main_Menu");


    }
}
