using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public int id;
    public string username;

    public string location;

    public static List<Player> playersOnline = new List<Player>();


    public Player(int _id, string _username, string _location)
    {
        id = _id;
        username = _username;
        location = _location;

    }
}
