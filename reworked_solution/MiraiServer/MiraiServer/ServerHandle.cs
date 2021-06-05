using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MiraiServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            Server.clients[_fromClient].SendIntoGame(_username);

            foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null && _client.player.location == "Shady")
                {
                    _client.SpawnPlayersInRoom("Shady");
                }
            }
                //Server.clients[_fromClient].SpawnPlayersInRoom("");
            //spawn rest of players
        }

        public static void PlayerMovement(int _fromClient, Packet _packet)
        {
            bool[] _inputs = new bool[_packet.ReadInt()];
            for (int i = 0; i < _inputs.Length; i++)
            {
                _inputs[i] = _packet.ReadBool();
            }
            Quaternion _rotation = _packet.ReadQuaternion();

            Server.clients[_fromClient].player.SetInput(_inputs, _rotation);
        }

        public static void LoginRequest(int _fromClient, Packet _packet)
        {
            int _id = _packet.ReadInt();
            string _username = _packet.ReadString();
            string _password = _packet.ReadString();

            Server.clients[_fromClient].ProcessLogin(_fromClient, _username, _password);
        }

        public static void RemovePlayer(int _fromClient, Packet _packet)
        {
            int _id = _packet.ReadInt();
            string _username = _packet.ReadString();

            Server.playersOnline.Remove(_username);

            ServerSend.RemovePlayerReceived(_fromClient);
        }

        public static void ChangeRoomRequest(int _fromClient, Packet _packet)
        {
            Console.WriteLine("received change room req");
            string _room = _packet.ReadString();



            /*foreach (Player _player in Server.playersOnline)
            {
                if (_player.id == _fromClient)
                {
                    _player.location = _room;
                }
            }*/

            // find prev val, pop from list
            // add to new room list
            // serversend.spawn player ? for all in new room
            // serversend.removep layer for all in old room

            //changer player loc to new
            //spawn players in room

            // all other clients remove this player
            ServerSend.RemovePlayerReceived(_fromClient);
            // this client removes all other players
            ServerSend.RemovePlayers(_fromClient);

            foreach (Client _client in Server.clients.Values)
            {
                if (_client.id == _fromClient)
                {
                    _client.player.location = _room;
                    ServerSend.ChangeRoom(_fromClient, _room);
                }
            }

            foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null && _client.player.location == _room)
                {
                    // all clients in this room spawn everyone in the room
                    ServerSend.RemovePlayers(_client.id);
                    _client.SpawnPlayersInRoom(_room);
                    Console.WriteLine("all players in room " + _room + " spawned for player " + _client.player.username);
                }
                /*if (_client.id == _fromClient)
                {
                    // this client is added to this room
                    _client.player.location = _room;
                    // this client spawns all clients in this room
                    _client.SpawnPlayersInRoom(_room);
                    Console.WriteLine("all players in room " + _room + " spawned for player " + _client.player.username);

                }*/
            }

            /*foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null)
                {
                    if (_client.id == _fromClient)
                    {
                        _client.player.location = _room;
                        // despawn all other playres in previos uroom
                        ServerSend.RemovePlayers(_fromClient);

                        _client.SpawnPlayersInRoom(_room);
                    }
                }
               
            }*/



            //ServerSend.ChangeRoom(_fromClient, _room);
        }
    }
}