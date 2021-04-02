using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangeRoom : MessageBase
{
    public int connectionID;
    public string newLocation;

    public void SwitchRoom()
    {
        NetworkServer.SendToClient(connectionID, MessageType.ChangeRoom, this);
        //NetworkManager.Instance.connectedPlayers.Add(this);
    }
}
