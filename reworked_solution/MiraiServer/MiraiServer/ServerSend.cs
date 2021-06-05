using System;
using System.Collections.Generic;
using System.Text;

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

        /*private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }*/
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

        public static void SpawnPlayer(int _toClient, Player _player)
        {
            int numInRoom = 0;
            List<int> ids = new List<int>();

            /*foreach (Player pleyer in Server.playersOnline)
            {
                if (pleyer.location == _player.location)
                {
                    numInRoom++;
                    ids.Add(pleyer.id);
                }
            }*/

            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);
                _packet.Write(_player.rotation);
                _packet.Write(numInRoom);
                for (int i = 0; i < numInRoom; i++)
                {
                    _packet.Write(ids[i]);
                }

                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerPosition(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.position);

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
            Console.WriteLine("removeplayerreceived sending to client...");
            using (Packet _packet = new Packet((int)ServerPackets.removePlayerReceived))
            {
                _packet.Write(_toClient);

                SendTCPDataToAll(_toClient, _packet);
                Console.WriteLine($"sent to all except {_toClient}");
            }
        }

        public static void RemovePlayers(int _toClient)
        {
            Console.WriteLine("remove all playres for single client req");
            using (Packet _packet = new Packet((int)ServerPackets.removePlayers))
            {
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
                Console.WriteLine($"sent only to guy changing room {_toClient}");
            }
        }


        public static void ChangeRoom(int _toClient, string _room)
        {
            Console.WriteLine("changeRoom sending to client...");
            using (Packet _packet = new Packet((int)ServerPackets.changeRoom))
            {
                _packet.Write(_toClient);
                _packet.Write(_room);

                SendTCPData(_toClient, _packet);
            }

            RemovePlayerReceived(_toClient);
        }
        #endregion
    }
}