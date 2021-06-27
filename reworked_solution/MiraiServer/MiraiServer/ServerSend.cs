using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MiraiServer
{
    class ServerSend
    {
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);
        }

        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }
        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }

        #region Packets

        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }
        }

        /*
         * intiialize new var num of playerse in room as 0
         * create a new list of "ids"
         * write id, username, position, rotation, list of ids (assume nothing insde)
         */
        public static void SpawnPlayer(int _toClient, Player _player, string _room)
        {

            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);
                _packet.Write(_player.rotation);
                _packet.Write(_room);

                SendTCPData(_toClient, _packet);

                Console.WriteLine($"ServerSend.cs - SpawnPlayer(): Spawning player {_player.username} for client with ID {_toClient}");
            }
        }

        public static void PlayerPosition(Player _player, float _flip, Vector3 _targetPos)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.position);
                _packet.Write(_flip);
                _packet.Write(_targetPos);

                SendUDPDataToAll(_packet);

            }
        }

        public static void PlayerRotation(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerRotation))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.rotation);

                SendUDPDataToAll(_player.id, _packet);
            }
        }

        public static void LoginRequestReceived(int _toClient, string _username, int _requestCode)
        {
            Console.WriteLine("sending login request received...");
            using (Packet _packet = new Packet((int)ServerPackets.loginRequestReceived))
            {
                _packet.Write(_toClient);
                _packet.Write(_username);
                _packet.Write(_requestCode);


                SendTCPData(_toClient, _packet);
            }
        }

        public static void RemovePlayerReceived(int _toClient)
        {
            using (Packet _packet = new Packet((int)ServerPackets.removePlayerReceived))
            {
                _packet.Write(_toClient);

                SendTCPDataToAll(_toClient, _packet);
                Console.WriteLine($"ServerSend.cs - RemovedPlayerReceived(): Every client removing player with ID {_toClient}");
            }
        }

        public static void RemovePlayers(int _toClient)
        {
            using (Packet _packet = new Packet((int)ServerPackets.removePlayers))
            {
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
                Console.WriteLine($"ServerSend.cs - RemovePlayers(): Player with ID {_toClient} has removed all other players");
            }
        }


        public static void ChangeRoom(int _toClient, string _room)
        {
            
            using (Packet _packet = new Packet((int)ServerPackets.changeRoom))
            {
                _packet.Write(_toClient);
                _packet.Write(_room);

                SendTCPData(_toClient, _packet);
                Console.WriteLine($"ServerSend.cs - ChangeRoom: Client with ID {_toClient} visually changed rooms"); // the actual visual ui change room
            }

            // RemovePlayerReceived(_toClient);
        }

        public static void ChangeClothes(int _thatClient, List<int> _items)
        {
            using (Packet _packet = new Packet((int)ServerPackets.changeClothes))
            {
                _packet.Write(_thatClient);
                _packet.Write(_items);

                SendUDPDataToAll(_packet);
            }
        }

        public static void SyncInventory(int _toClient, int _itemID)
        {
            // for now is using a single item id for testing, but in the future shold try sending text file.
            using (Packet _packet = new Packet((int)ServerPackets.syncInventory))
            {
                _packet.Write(_toClient);
                _packet.Write(_itemID);

                //Console.WriteLine("sending packet to client to add item..");
                SendTCPData(_toClient, _packet);
            }
        }

        #endregion
    }
}