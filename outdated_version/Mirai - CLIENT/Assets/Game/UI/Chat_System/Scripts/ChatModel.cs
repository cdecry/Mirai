using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatModel
{
    public string message;
    public void SendMessage()
    {
        //process msg
        ChatMessage msg = new ChatMessage
        {
            playerName = PlayerInfo.Instance.PlayerName,
            target = "WorldChat",
            message = this.message,
        };

        msg.HandleMessage();
    }
}
