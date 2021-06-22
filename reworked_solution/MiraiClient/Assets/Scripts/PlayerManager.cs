using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public string location;

    public PlayerManager(int _id, string _username, string _location)
    {
        id = _id;
        username = _username;
        location = _location;

    }

}