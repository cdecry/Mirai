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

        //filter placeholder, add script later
        if (message.Contains("shit"))
        {
            Debug.Log("no swearing dumy");
        }
        else
        {
            Debug.Log("sending message!");
            Client.Instance.networkClient.Send(MessageType.ChatMessage, this);
        }
    }

    public void HandleMessageReceivedFromServer()
    {
        switch(target)
        {
            case "WorldChat":
                //create msg gameobj with provided msg
                Debug.Log(string.Format("Received new world chat messsage: {0} from connection id: {1}", message, connectionID));
                ChatController.Instance.CreateNewMessage(playerName, message);


                break;
        }
    }
}
