using System;
using System.Collections.Generic;
using System.Text;

namespace MiraiServer
{
    class Room
    {
       
        public static List<Dictionary<int, Player>> Rooms = new List<Dictionary<int, Player>>();
        // load in from db on start, for now here

        /*public Room(string _name, Dictionary<int, Player> _players)
        {
            name = _name;
            players = _players;
        }*/

        public void Move(string _name)
        {
            //ServerSend.ChangeRoom();
        }

    }
}
