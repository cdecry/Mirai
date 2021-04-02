using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ChangeRoom : MessageBase
{
    public int connectionID;
    public string newLocation;

    public void HandleTransition()
    {
        //SceneManager.LoadScene(newLocation);
        Client.Instance.networkClient.Send(MessageType.ChangeRoom, this);
    }
}
