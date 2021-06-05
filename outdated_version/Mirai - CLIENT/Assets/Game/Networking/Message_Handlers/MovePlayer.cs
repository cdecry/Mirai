using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlayer : MessageBase
{
    public int connectionID;
    public string keyPressed;
    public Vector2 playerPosition;

    public void HandleMovement()
    {
        Client.Instance.networkClient.Send(MessageType.MovePlayer, this);
    }

}
