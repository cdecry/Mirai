using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

//client login, implement mvc in future?

public class Client : MonoBehaviour
{

    //public InputField usernameInputField, passwordInputField;

    //NetworkClient _client;

    private static NetworkClient _client;
    public static NetworkClient Instance
    {
        get
        {
            if (_client == null)
            {
                throw new Exception();
            }
            return _client;
        }
    }

    void Awake()
    {
        Application.runInBackground = true;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Application.runInBackground = true;
        Connect();
    }

    /*public void Login()
    {
        LoginRequest user = new LoginRequest 
        { 
            username = usernameInputField.text,
            password = passwordInputField.text
        };
    }*/


void Connect()
    {
        _client = new NetworkClient();
        RegisterHandlers();
        _client.Connect("localhost", 7777);
    }

    void RegisterHandlers()
    {
        _client.RegisterHandler(MessageType.Connect, OnConnectedToServer); //official
        _client.RegisterHandler(MessageType.Disconnect, OnDisconnectedFromServer);
        _client.RegisterHandler(MessageType.ChatMessage, OnChatMessageReceivedFromServer);
        _client.RegisterHandler(MessageType.LoginRequest, OnLoginRequestReceivedFromServer);
    }

    void OnConnectedToServer(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
        ChatMessage msg = new ChatMessage();
        msg.target = null;
        msg.message = "helo, server!";

        msg.HandleMessage();
    }

    void OnDisconnectedFromServer(NetworkMessage netMsg)
    {
        Debug.Log("Dropped from server");
    }

    void OnChatMessageReceivedFromServer(NetworkMessage netMsg)
    {
        ChatMessage replyFromServer = netMsg.ReadMessage<ChatMessage>();
        replyFromServer.HandleMessageReceivedFromServer();
    }

    void OnLoginRequestReceivedFromServer(NetworkMessage netMsg)
    {
        LoginRequest user = netMsg.ReadMessage<LoginRequest>();
        user.ProcessServerResponse();
    }

    

}
