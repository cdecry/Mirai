using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        List<int> ids = new List<int>();

        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        int _numInRoom = _packet.ReadInt();

        for(int i = 0; i < _numInRoom; i++)
        {
            ids.Add(_packet.ReadInt());
        }

        //!! add users to spawn, read lists  in packets
        //List _playersToSpawn = _packet.ReadList();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation, ids);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        if (GameManager.players.ContainsKey(_id))
        {
            GameManager.players[_id].transform.position = _position;
            
            //SceneManager.LoadScene("Shady");
        }
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        if (GameManager.players.ContainsKey(_id))
        {
            GameManager.players[_id].transform.rotation = _rotation;
        }
    }

    public static void LoginRequestReceived(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        int _requestCode = _packet.ReadInt();

        switch (_requestCode)
        {
            //login success
            case 0:
                Debug.Log("login successful! spawning player...");
                //assign playerInfo username

                /*Player player = new Player(_id, _username, "Shady");

                GameManager.playersOnline.Add(player);
                foreach (Player _player in GameManager.playersOnline)
                {
                    Debug.Log(_player.username);
                }*/

                //spawn player
                SceneManager.LoadScene("Shady");
                Debug.Log("loaded scene.");
                break;
            //invalid req for user/pass
            case 1:
                Debug.Log("Incorrect user/pass");
                Client.instance.Disconnect();
                //UIManager.instance.startMenu.SetActive(true);
                //disconnect
                break;
            default:
                Debug.Log("server offline");
                //disconnect
                break;
        }
    }

    public static void RemovePlayerReceived(Packet _packet)
    {
        int _id = _packet.ReadInt();
        // linq thing faster
        foreach (GameObject _player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (_player.name == "Player(Clone)")
            {
                if (_player.GetComponent<PlayerManager>().id == _id)
                {
                    GameManager.players.Remove(_id);
                    GameObject.Destroy(_player);
                }
            }
        }
        
        Debug.Log("remove player received");

    }

    public static void RemovePlayers(Packet _packet)
    {
        int _id = _packet.ReadInt();
        // linq thing faster
        foreach (GameObject _player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (_player.name == "Player(Clone)")
            {
                GameManager.players.Remove(_player.GetComponent<PlayerManager>().id);
                GameObject.Destroy(_player);
            }
        }

        Debug.Log("remove players received");

    }

    public static void ChangeRoom(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _room = _packet.ReadString();
        // linq thing faster

        GameManager.players[_id].location = _room;
        SceneManager.LoadScene("Slush-N-Rush");

        Debug.Log("scene loaded");

    }

}