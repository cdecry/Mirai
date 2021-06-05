using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class LogoutRequest : MessageBase
{
    // player connid
    public int connectionID;

    public void HandleRequest()
    {
        ProcessLogout();
    }

    void ProcessLogout()
    {
        var found = NetworkManager.Instance.connectedPlayers.FirstOrDefault(player => player.connectionID == this.connectionID);

        if (found!= null)
        {
            NetworkManager.Instance.connectedPlayers.Remove(found);
        }

        /*int index = NetworkManager.Instance.connectedPlayers.FindIndex(user => user.connectionID == this.connectionID);
        NetworkManager.Instance.connectedPlayers.RemoveAt(index);*/
    }

}
