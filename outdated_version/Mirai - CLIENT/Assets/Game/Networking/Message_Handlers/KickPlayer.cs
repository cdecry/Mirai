using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KickPlayer : MessageBase
{
    public int connectionID;
    public void HandleRequest()
    {
        ProcessKick();
    }

    void ProcessKick()
    {
        Client.Instance.networkClient.Disconnect();
    }
}
