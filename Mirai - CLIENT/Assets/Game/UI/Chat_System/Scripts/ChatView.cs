using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatView : MonoBehaviour
{
    public InputField chatMessageInput;

    public void ProcessChatMessage()
    {
        if (!string.IsNullOrWhiteSpace(chatMessageInput.text))
        {
            ChatModel newChatMessage = new ChatModel
            {
                message = chatMessageInput.text
            };

            newChatMessage.SendMessage();
            chatMessageInput.text = "";
        }
        else
        {
            chatMessageInput.text = "";
        }
    }
}
