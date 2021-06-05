using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlayer : MessageBase
{
    public int connectionID;
    public string keyPressed;
    public Vector2 playerPosition;

    public void UpdatePlayerPosition()
    {
        NetworkServer.SendToClient(connectionID, MessageType.MovePlayer, this);
    }

}
