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
