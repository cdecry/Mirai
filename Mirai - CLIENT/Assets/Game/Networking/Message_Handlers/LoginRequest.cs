using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoginRequest : MessageBase
{
    public string username;
    public string password;
    public int requestCode;
    public int connectionID;

    public void HandleRequest()
    {
        //encrypt pw
        password = Encryptor.Encrypt(password);
        Client.Instance.networkClient.Send(MessageType.LoginRequest, this);
    }

    public void ProcessServerResponse()
    {

        switch (requestCode)
        {
            //login success
            case 0:
                //assign playerInfo username
                PlayerInfo.Instance.PlayerName = username;
                PlayerInfo.Instance.ipAddress = Client.Instance.networkClient.connection.address;
                ClientScene.AddPlayer(Client.Instance.networkClient.connection, 0);
                SceneManager.LoadScene("Alley");
                break;
            //invalid req for user/pass
            case 1:
                Debug.Log("Incorrect user/pass");
                Client.Instance.networkClient.Disconnect();
                break;
            // already logged in
            case 2:
                Debug.Log("Already logged in,, kicking player");
                PlayerInfo.Instance.PlayerName = username;
                PlayerInfo.Instance.ipAddress = Client.Instance.networkClient.connection.address;
                ClientScene.AddPlayer(Client.Instance.networkClient.connection, 0);
                SceneManager.LoadScene("Alley");
                break;
            default:
                Debug.Log("server offline");
                Client.Instance.networkClient.Disconnect();
                break;
        }
    }
}
