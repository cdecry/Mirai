using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LogoutRequest : MessageBase
{
    // player connid
    public int connectionID;

    public void HandleRequest()
    {
        Client.Instance.networkClient.Send(MessageType.LogoutRequest, this);
    }

}
