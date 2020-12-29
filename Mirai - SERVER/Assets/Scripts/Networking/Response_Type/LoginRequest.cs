using System;
using System.Collections.Specialized;
using System.Net;
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

    public const string DATA_URL_LOGIN = "http://localhost:81/login.php";

    public void HandleRequest()
    {
        ProcessLogin();
    }

    void ProcessLogin()
    {
        using (WebClient request = new WebClient())
        {
            NameValueCollection form = new NameValueCollection();
            form.Add("username", username);
            form.Add("password", password);
            byte[] responseData = request.UploadValues(DATA_URL_LOGIN, form);

            Debug.Log("Response received from server: " + Encoding.UTF8.GetString(responseData));

            requestCode = -1;
            int.TryParse(Encoding.UTF8.GetString(responseData), out requestCode);

            // just for debug dlt later
            switch (requestCode)
            {
                case 0:
                    Debug.Log("Login successful");

                    var dbUsername = Encoding.UTF8.GetString(responseData).Split(' ')[1];
                    username = dbUsername;

                    NetworkServer.SendToClient(connectionID, MessageType.LoginRequest, this);
                    break;
                case 1:
                    Debug.Log("Invalid username/password. Please try again.");
                    break;
                default:
                    Debug.Log("Server offline");
                    break;
            }
        }
    }

}
