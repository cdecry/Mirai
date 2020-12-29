using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChatMessage : MessageBase
{

    public int connectionID;

    public string playerName;

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
        //check ilegal stufys, sned back reponse

        Debug.Log("Handling Message for connection: " + connectionID);

        switch(target)
        {
            case "WorldChat":
                Debug.Log("Request for world chat message: " + message);
                NetworkServer.SendToAll(MessageType.ChatMessage, this);
                break;
        }
    }

}
