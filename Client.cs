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

    public InputField usernameInputField, passwordInputField;

    NetworkClient _client;

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

    public void Login()
    {
        AuthenticateUser user = new AuthenticateUser { username = usernameInputField.text, password = passwordInputField.text, ipAddress = IPManager.GetIP(ADDRESSFAM.IPv4) };

        Debug.Log("ip login: " + user.ipAddress);

        string passwordEncryption = user.password;

        using (MD5 md5Hash = MD5.Create())
        {
            string hash = GetMd5Hash(md5Hash, passwordEncryption);


            //signup pass added to db as md5 w bcrypt, login uses normal pw converted to md5 to match
            if (VerifyMd5Hash(md5Hash, passwordEncryption, hash))
            {
                Debug.Log("hashes are identical: " + hash);
                user.password = hash;
                _client.Send(MessageType.AuthenticateUser, user);
            }
            else
            {
                Debug.Log("hashes are different");
            }


        }
        //MD5 encryption
    }

    static string GetMd5Hash(MD5 md5Hash, string input)
    {
        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();
        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    // Verify a hash against a string.
    static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(md5Hash, input);
        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


void Connect()
    {
        _client = new NetworkClient();
        RegisterHandlers(); 
        _client.Connect("localhost", 7777);
    }

    void RegisterHandlers()
    {
        _client.RegisterHandler(MessageType.Connect, OnConnectedToServer);
        _client.RegisterHandler(MessageType.Disconnect, OnDisconnectedFromServer);
        _client.RegisterHandler(MessageType.ChatMessage, OnChatMessageReceivedFromServer);
        _client.RegisterHandler(MessageType.AuthenticateUser, OnAuthenticateUserResponseFromServer);
    }

    void OnConnectedToServer(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
        //sending custom msg to pleyer
        ChatMessage msg = new ChatMessage();
        msg.target = null;
        msg.message = "helo, server!";

        _client.Send(MessageType.ChatMessage, msg);
    }

    void OnDisconnectedFromServer(NetworkMessage netMsg)
    {
        Debug.Log("Dropped from server");
    }

    void OnChatMessageReceivedFromServer(NetworkMessage netMsg)
    {
        Debug.Log("Reply from server: " + netMsg.ReadMessage<ChatMessage>().message);
    }

    void OnAuthenticateUserResponseFromServer(NetworkMessage netMsg)
    {
        //load game scene if reponse all gudd
        AuthenticateUser user = netMsg.ReadMessage<AuthenticateUser>();

        Debug.Log(string.Format("Received from server: Username: {0}  Pass: {1}  Request Code: {2}", user.username, user.password, user.requestCode));

        switch(user.requestCode)
        {
            case 0:
                //login success
                SceneManager.LoadScene("Game");
                break;
            case 1:
                //invalid req
                Debug.Log("Incorrect username/password.");
                break;
        }

    }

}
