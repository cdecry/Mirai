using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
    private static ChatController _instance;
    public static ChatController Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new System.Exception();
            }
            return _instance;
        }
    }

    public GameObject messagePrefab;
    public Transform messageContainer;

    private void Awake()
    {
        _instance = this;
    }

    public void CreateNewMessage(string playerName, string newMessage)
    {
        GameObject message = Instantiate(messagePrefab) as GameObject;
        message.GetComponent<Text>().text = string.Format("{0}: {1}", playerName, newMessage);
        message.transform.SetParent(messageContainer, false);
        //message.transform.localScale = messagePrefab.transform.localScale;
    }
}
