using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public string ipAddress;
    public int port;

    // init
    void Start()
    {
        Application.runInBackground = true;
        InitializeServer(ipAddress, port);
    }

    void InitializeServer(string ipAddress, int port)
    {
        RegisterHandlers();
        NetworkServer.Listen(port);
        Debug.Log("Server On: " + NetworkServer.active);
    }

    void RegisterHandlers()
    {
        NetworkServer.RegisterHandler(MessageType.Connect, OnConnected);
        NetworkServer.RegisterHandler(MessageType.Disconnect, OnDisconnected);
        NetworkServer.RegisterHandler(MessageType.ChatMessage, OnChatMessageReceived);
        NetworkServer.RegisterHandler(MessageType.LoginRequest, OnLoginRequestReceived);
    }

    void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Client connected: " + netMsg.conn.connectionId);

    }

    void OnDisconnected(NetworkMessage netMsg)
    {
        Debug.Log("Client dropped connection");
    }

    void OnChatMessageReceived(NetworkMessage netMsg)
    {
        ChatMessage sender = netMsg.ReadMessage<ChatMessage>();
        sender.connectionID = netMsg.conn.connectionId;
        sender.HandleMessage();
    }

    void OnLoginRequestReceived(NetworkMessage netMsg)
    {
        LoginRequest checkUser = netMsg.ReadMessage<LoginRequest>();
        checkUser.connectionID = netMsg.conn.connectionId;
        checkUser.HandleRequest();
    }

}
