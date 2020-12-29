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
        Client.Instance.Send(MessageType.LoginRequest, this);
    }

    public void ProcessServerResponse()
    {

        switch (requestCode)
        {
            //login success
            case 0:
                //assign playerInfo username
                PlayerInfo.Instance.PlayerName = username;

                SceneManager.LoadScene("Game");
                break;
            //invalid req for user/pass
            case 1:
                Debug.Log("Incorrect user/pass");
                break;
            default:
                Debug.Log("Server offline");
                break;
        }
    }
}
