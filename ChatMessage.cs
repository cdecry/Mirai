using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChatMessage : MessageBase
{

    public int connectionID;

    /// <summary>
    /// who to send msg to (ex gen, priv, group)
    /// </summary>
    public string target;

    /// <summary>
    /// msg content
    /// </summary>
    public string message;

    public void HandleMessage()
    {
        //logic for ilegal charcters to add

        Client.Instance.Send(MessageType.ChatMessage, this);
    }

}
