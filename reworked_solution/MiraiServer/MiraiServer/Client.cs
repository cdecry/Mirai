using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiraiServer
{
    class Client
    {
        public static int dataBufferSize = 4096;

        public int id;
        public Player player;
        public Inventory inventory;
        public TCP tcp;
        public UDP udp;

        public Client(int _clientId)
        {
            id = _clientId;
            tcp = new TCP(id);
            udp = new UDP(id);
        }

        public class TCP
        {
            public TcpClient socket;

            private readonly int id;
            private NetworkStream stream;
            private Packet receivedData;
            private byte[] receiveBuffer;

            public TCP(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                receivedData = new Packet();
                receiveBuffer = new byte[dataBufferSize];

                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);

                //ServerSend.Welcome(id, "Welcome to the server!");
            }

            public void SendData(Packet _packet)
            {
                try
                {
                    if (socket != null)
                    {
                        stream.BeginWrite(_packet.ToArray(), 0, _packet.Length(), null, null);
                    }
                }
                catch (Exception _ex)
                {
                    Console.WriteLine($"Error sending data to player {id} via TCP: {_ex}");
                }
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        Server.clients[id].Disconnect();
                        return;
                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(receiveBuffer, _data, _byteLength);

                    receivedData.Reset(HandleData(_data));
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch (Exception _ex)
                {
                    Console.WriteLine($"Error receiving TCP data: {_ex}");
                    Server.clients[id].Disconnect();
                }
            }

            private bool HandleData(byte[] _data)
            {
                int _packetLength = 0;

                receivedData.SetBytes(_data);

                if (receivedData.UnreadLength() >= 4)
                {
                    _packetLength = receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        return true;
                    }
                }

                while (_packetLength > 0 && _packetLength <= receivedData.UnreadLength())
                {
                    byte[] _packetBytes = receivedData.ReadBytes(_packetLength);
                    ThreadManager.ExecuteOnMainThread(() =>
                    {
                        using (Packet _packet = new Packet(_packetBytes))
                        {
                            int _packetId = _packet.ReadInt();
                            Server.packetHandlers[_packetId](id, _packet);
                        }
                    });

                    _packetLength = 0;
                    if (receivedData.UnreadLength() >= 4)
                    {
                        _packetLength = receivedData.ReadInt();
                        if (_packetLength <= 0)
                        {
                            return true;
                        }
                    }
                }

                if (_packetLength <= 1)
                {
                    return true;
                }

                return false;
            }

            public void Disconnect()
            {
                socket.Close();
                stream = null;
                receivedData = null;
                receiveBuffer = null;
                socket = null;
            }
        }

        

        public class UDP
        {
            public IPEndPoint endPoint;

            private int id;

            public UDP(int _id)
            {
                id = _id;
            }

            public void Connect(IPEndPoint _endPoint)
            {
                endPoint = _endPoint;
            }

            public void SendData(Packet _packet)
            {
                Server.SendUDPData(endPoint, _packet);
            }

            public void HandleData(Packet _packetData)
            {
                int _packetLength = _packetData.ReadInt();
                byte[] _packetBytes = _packetData.ReadBytes(_packetLength);

                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        Server.packetHandlers[_packetId](id, _packet);
                    }
                });
            }

            public void Disconnect()
            {
                endPoint = null;
            }
        }

        public void SendIntoGame(string _playerName, string _room)
        {

            player = new Player(id, _playerName, _room, new Vector3(0, 0, 0));
            inventory = new Inventory();

            Server.playersOnline.Add(player.username);

            Console.WriteLine($"added players online, list");
            Server.playersOnline.ForEach(Console.WriteLine);

            foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null)
                {
                    //added if
                    if (_client.id == id)
                    {
                        ServerSend.SpawnPlayer(_client.id, player, _room);

                        Console.WriteLine($"client id: {_client.id}, username: {player.username}, player id: {player.id}");
                        _client.inventory.AddItem(1);
                        //ServerSend.SyncInventory(_client.id, 1);   //SERVER INVENT TEST
                    }
                    
                }
            }
        }

        public void SpawnPlayersInRoom(string room)
        {

            //check room


            foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null)
                {
                    Console.WriteLine(_client.player.username);
                    if (_client.id != id)
                    {
                        if(_client.player.location == room)
                        {
                            ServerSend.SpawnPlayer(id, _client.player, room);
                        }
                    }
                }
            }

        }

        public async Task ProcessLogin(int _id, string _username, string _password)
        {
            Console.WriteLine("starting ProcessLogin() in Client.cs");
            using (WebClient request = new WebClient())
            {
                NameValueCollection form = new NameValueCollection();
                form.Add("username", _username);
                form.Add("password", _password);
                byte[] responseData = await request.DownloadDataTaskAsync(new Uri("http://localhost:81/login.php"));
                //byte[] responseData = request.UploadValues("http://localhost:81/login.php", form);
                Console.WriteLine($"Response received from server: { Encoding.UTF8.GetString(responseData)}");

                int requestCode = -1;
                int.TryParse(Encoding.UTF8.GetString(responseData), out requestCode);

                if (Encoding.UTF8.GetString(responseData) == "Error connecting to server")
                {
                    requestCode = -1;
                }
                else if (Server.playersOnline.SingleOrDefault(s => s == _username) != null)
                {
                    requestCode = -1;
                    Console.WriteLine("user already logged in, this not sent to player yet");
                }

                ServerSend.LoginRequestReceived(_id, _username, requestCode);

                if (requestCode == 0)
                {
                    ServerSend.Welcome(id, "Welcome to the server!");
                    //InitializeItemDB();
                }
            }
            //ServerSend.LoginRequestReceived(_id, _username, 0);
            //ServerSend.Welcome(id, "Welcome to the server!");
            // login request received send to client, logi
        }

        /*
        public void InitializeItemDB()
        {
            // rn jsut chec, in the future sent req to db for itemdb AND user invent
            //Console.WriteLine("ItemDB length: " + ItemDatabase.items.Count + ", First item is: " + ItemDatabase.items[0].name);
            Server
        }*/


            public void Disconnect()
        {
            Console.WriteLine($"{tcp.socket.Client.RemoteEndPoint} has disconnected.");
            
            ThreadManager.ExecuteOnMainThread(() =>
            {
                player = null;
            });
            

            tcp.Disconnect();
            udp.Disconnect();
        }
    }
}