using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MessageType : MsgType
{
    public const short ChatMessage = 48;
    public const short LoginRequest = 49;
    public const short LogoutRequest = 50;
    public const short KickPlayer = 51;
    public const short MovePlayer = 52;
    public const short ChangeRoom = 53;
}
